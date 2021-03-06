using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.Engine
{
    public class DeleteModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public DeleteModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Engines Engines { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Engines = await _context.Engines
                .Include(e => e.Manufacturer).FirstOrDefaultAsync(m => m.ENG_Code == id);

            if (Engines == null)
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

            Engines = await _context.Engines.FindAsync(id);

            if (Engines != null)
            {
                _context.Engines.Remove(Engines);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
