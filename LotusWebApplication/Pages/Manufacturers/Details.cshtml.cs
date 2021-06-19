using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.Manufacturer
{
    public class DetailsModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public DetailsModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        public LotusWebApplication.Models.Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturer
                .Include(m => m.NationalAviationAuthority).FirstOrDefaultAsync(m => m.MAN_Code == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
