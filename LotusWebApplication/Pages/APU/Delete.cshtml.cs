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
    public class DeleteModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public DeleteModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LotusWebApplication.Models.APU APU { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            APU = await _context.APU
                .Include(a => a.Manufacturer).FirstOrDefaultAsync(m => m.APU_Code == id);

            if (APU == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            APU = await _context.APU.FindAsync(id);

            if (APU != null)
            {
                _context.APU.Remove(APU);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
