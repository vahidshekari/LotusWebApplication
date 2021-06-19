using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.APU
{
    public class IndexModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public IndexModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        public IList<LotusWebApplication.Models.APU> APU { get;set; }

        public async Task OnGetAsync()
        {
            APU = await _context.APU
                .Include(a => a.Manufacturer).ToListAsync();
        }
    }
}
