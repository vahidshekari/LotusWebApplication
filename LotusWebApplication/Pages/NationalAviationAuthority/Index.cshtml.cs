using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.NationalAviationAuthority
{
    public class IndexModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public IndexModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        public IList<LotusWebApplication.Models.NationalAviationAuthority> NationalAviationAuthority { get;set; }

        public async Task OnGetAsync()
        {
            NationalAviationAuthority = await _context.NationalAviationAuthority.ToListAsync();
        }
    }
}
