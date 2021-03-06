using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.AircraftType
{
    public class DetailsModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public DetailsModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

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

            if (AircraftType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
