using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.APU
{
    public class EditModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public EditModel(LotusWebApplication.Models.AppDBContext context)
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
           ViewData["APU_MAN_Code"] = new SelectList(_context.Manufacturer, "MAN_Code", "MAN_Desc");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(APU).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APUExists(APU.APU_Code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool APUExists(short id)
        {
            return _context.APU.Any(e => e.APU_Code == id);
        }
    }
}
