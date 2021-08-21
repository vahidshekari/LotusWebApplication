using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.AircraftFlightLog
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
        ViewData["AFL_APT_TakeOff_Code"] = new SelectList(_context.Airport, "APT_Code", "APT_IATACode");
        ViewData["AFL_APT_Landing_Code"] = new SelectList(_context.Airport, "APT_Code", "APT_IATACode");
        ViewData["AFL_FLT_Code"] = new SelectList(_context.Fleet, "FLT_Code", "FLT_Registration");
            return Page();
        }

        [BindProperty]
        public LotusWebApplication.Models.AircraftFlightLog AircraftFlightLog { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AircraftFlightLog.Add(AircraftFlightLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
