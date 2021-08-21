using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LotusWebApplication.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace LotusWebApplication.Pages.AircraftType
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
                    TempData["maxsize"] = "File can't be larger than 10MB.";
                    return null;
                }
                string uploadsfolder = Path.Combine(webHostEnvironment.WebRootPath, "assets/AircraftTypeCertificate");
                uniquefilename = Guid.NewGuid().ToString() + "_" + AircraftType.ACT_OfficialName + Path.GetExtension(formFile.FileName);
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
        ViewData["ACT_APU_Code"] = new SelectList(_context.APU, "APU_Code", "APU_Description");
        ViewData["ACT_ENG_Code"] = new SelectList(_context.Engines, "ENG_Code", "ENG_Description");
        ViewData["ACT_MAN_Code"] = new SelectList(_context.Manufacturer, "MAN_Code", "MAN_Desc");
            return Page();
        }

        [BindProperty]
        public LotusWebApplication.Models.AircraftType AircraftType { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            AircraftType.ACT_TCPdfFile = ProcessedFile();
            _context.AircraftType.Add(AircraftType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
