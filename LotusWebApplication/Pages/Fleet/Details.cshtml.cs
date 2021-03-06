using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.Fleet
{
    public class DetailsModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public DetailsModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        public LotusWebApplication.Models.Fleet Fleet { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fleet = await _context.Fleet
                .Include(f => f.AircraftType).FirstOrDefaultAsync(m => m.FLT_Code == id);

            if (Fleet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
