using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LotusWebApplication.Pages.AircraftType
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

        [BindProperty]
        public LotusWebApplication.Models.AircraftType AircraftType { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AircraftType = await _context.AircraftType
                .Include(a => a.APU)
                .Include(a => a.Engines)
                .Include(a => a.Manufacturer).FirstOrDefaultAsync(m => m.ACT_Code == id);
            attach = "~/assets/AircraftTypeCertificate/" + AircraftType.ACT_TCPdfFile;
            if (AircraftType == null)
            {
                return NotFound();
            }
           ViewData["ACT_APU_Code"] = new SelectList(_context.APU, "APU_Code", "APU_Description");
           ViewData["ACT_ENG_Code"] = new SelectList(_context.Engines, "ENG_Code", "ENG_Description");
           ViewData["ACT_MAN_Code"] = new SelectList(_context.Manufacturer, "MAN_Code", "MAN_Desc");
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
                uniquefilename = Guid.NewGuid().ToString() + "_" + AircraftType.ACT_OfficialName + Path.GetExtension(formFile.FileName);
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
                AircraftType.ACT_TCPdfFile = ProcessedFile();
            }
            _context.Attach(AircraftType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftTypeExists(AircraftType.ACT_Code))
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

        private bool AircraftTypeExists(short id)
        {
            return _context.AircraftType.Any(e => e.ACT_Code == id);
        }
    }
}
