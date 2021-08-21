using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.Fleet
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
        ViewData["FLT_ACT_Code"] = new SelectList(_context.AircraftType, "ACT_Code", "ACT_OfficialName");
            return Page();
        }

        [BindProperty]
        public LotusWebApplication.Models.Fleet Fleet { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Fleet.Add(Fleet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
