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
    public class IndexModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public IndexModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        public IList<LotusWebApplication.Models.Manufacturer> Manufacturer { get;set; }

        public async Task OnGetAsync()
        {
            Manufacturer = await _context.Manufacturer
                .Include(m => m.NationalAviationAuthority).ToListAsync();
        }
    }
}
