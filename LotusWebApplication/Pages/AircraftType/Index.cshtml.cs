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
    public class IndexModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public IndexModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        public IList<LotusWebApplication.Models.AircraftType> AircraftType { get;set; }

        public async Task OnGetAsync()
        {
            AircraftType = await _context.AircraftType
                .Include(a => a.APU)
                .Include(a => a.Engines)
                .Include(a => a.Manufacturer).ToListAsync();
        }
    }
}
