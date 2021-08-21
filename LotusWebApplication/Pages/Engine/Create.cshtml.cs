using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LotusWebApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LotusWebApplication.Pages.Engine
{
    public class CreateModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CreateModel(AppDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public IFormFile formFile { get; set; }
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
        public IActionResult OnGet()
        {
        ViewData["ENG_MAN_Code"] = new SelectList(_context.Manufacturer, "MAN_Code", "MAN_Desc");
            return Page();
        }

        [BindProperty]
        public Engines Engines { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Engines.Eng_TCPDFFile = ProcessedFile();
            _context.Engines.Add(Engines);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
