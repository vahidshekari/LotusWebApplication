using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.AircraftFlightLog
{
    public class EditModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public EditModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LotusWebApplication.Models.AircraftFlightLog AircraftFlightLog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AircraftFlightLog = await _context.AircraftFlightLog
                .Include(a => a.DeptAirport)
                .Include(a => a.DestAirport)
                .Include(a => a.Fleet).FirstOrDefaultAsync(m => m.AFL_Code == id);

            if (AircraftFlightLog == null)
            {
                return NotFound();
            }
           ViewData["AFL_APT_TakeOff_Code"] = new SelectList(_context.Airport, "APT_Code", "APT_IATACode");
           ViewData["AFL_APT_Landing_Code"] = new SelectList(_context.Airport, "APT_Code", "APT_IATACode");
           ViewData["AFL_FLT_Code"] = new SelectList(_context.Fleet, "FLT_Code", "FLT_Code");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AircraftFlightLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftFlightLogExists(AircraftFlightLog.AFL_Code))
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

        private bool AircraftFlightLogExists(int id)
        {
            return _context.AircraftFlightLog.Any(e => e.AFL_Code == id);
        }
    }
}
