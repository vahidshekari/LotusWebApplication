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
    public class IndexModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public IndexModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        public IList<LotusWebApplication.Models.AircraftFlightLog> AircraftFlightLog { get;set; }

        public async Task OnGetAsync()
        {
            AircraftFlightLog = await _context.AircraftFlightLog
                .Include(a => a.DeptAirport)
                .Include(a => a.DestAirport)
                .Include(a => a.Fleet).ToListAsync();
        }
    }
}
