using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.AircraftFlightLog
{
    public class DeleteModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public DeleteModel(LotusWebApplication.Models.AppDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AircraftFlightLog = await _context.AircraftFlightLog.FindAsync(id);

            if (AircraftFlightLog != null)
            {
                _context.AircraftFlightLog.Remove(AircraftFlightLog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
