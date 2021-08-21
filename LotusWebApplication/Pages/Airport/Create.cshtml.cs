using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.Airport
{
    public class CreateModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public CreateModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["APT_CTY_Code"] = new SelectList(_context.City, "CTY_Code", "CTY_Name_En");
            ViewData["APT_ALT_APT_Code_1"] = new SelectList(_context.Airport, "APT_Code", "APT_NameEn");
            ViewData["APT_ALT_APT_Code_2"] = new SelectList(_context.Airport, "APT_Code", "APT_NameEn");
            ViewData["APT_ALT_APT_Code_3"] = new SelectList(_context.Airport, "APT_Code", "APT_NameEn");
            return Page();
        }

        [BindProperty]
        public LotusWebApplication.Models.Airport Airport { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Airport.Add(Airport);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
