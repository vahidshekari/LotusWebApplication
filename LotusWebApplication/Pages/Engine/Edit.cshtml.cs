using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace LotusWebApplication.Pages.Engine
{
    public class EditModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EditModel(LotusWebApplication.Models.AppDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public IFormFile formFile { get; set; }
        [BindProperty]
        public string attach { get; set; }
        public Engines Engines { get; set; }
     
        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            Engines = await _context.Engines
                .Include(e => e.Manufacturer).FirstOrDefaultAsync(m => m.ENG_Code == id);
            attach = "~/assets/EngineTypeCertificate/" + Engines.Eng_TCPDFFile;
            if (Engines == null)
            {
                return NotFound();
            }
           ViewData["ENG_MAN_Code"] = new SelectList(_context.Manufacturer, "MAN_Code", "MAN_Desc");
            return Page();
        }
        private string ProcessedFile()
        {
            string uniquefilename = null;
            if (formFile != null)
            {
                if (formFile.Length > 10485760)
                {
                    TempData["maxsize"] = "File can't be larger tha 10MB.";
                    return null;
                }
                string uploadsfolder = Path.Combine(webHostEnvironment.WebRootPath, "assets/EngineTypeCertificate");
                uniquefilename = Guid.NewGuid().ToString() + "_" + Engines.ENG_Description + Path.GetExtension(formFile.FileName);
                string filePath = Path.Combine(uploadsfolder, uniquefilename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            return uniquefilename;
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (formFile != null)
            {
                Engines.Eng_TCPDFFile = ProcessedFile();
            }
            _context.Attach(Engines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnginesExists(Engines.ENG_Code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EnginesExists(short id)
        {
            return _context.Engines.Any(e => e.ENG_Code == id);
        }
    }
}
