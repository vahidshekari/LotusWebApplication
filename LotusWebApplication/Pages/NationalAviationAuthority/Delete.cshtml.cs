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
    public class DeleteModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public DeleteModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LotusWebApplication.Models.NationalAviationAuthority NationalAviationAuthority { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NationalAviationAuthority = await _context.NationalAviationAuthority.FirstOrDefaultAsync(m => m.NAA_Code == id);

            if (NationalAviationAuthority == null)
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

            NationalAviationAuthority = await _context.NationalAviationAuthority.FindAsync(id);

            if (NationalAviationAuthority != null)
            {
                _context.NationalAviationAuthority.Remove(NationalAviationAuthority);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
