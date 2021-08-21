using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.Airport
{
    public class EditModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public EditModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LotusWebApplication.Models.Airport Airport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airport = await _context.Airport
                .Include(a => a.City).FirstOrDefaultAsync(m => m.APT_Code == id);

            if (Airport == null)
            {
                return NotFound();
            }
            ViewData["APT_CTY_Code"] = new SelectList(_context.City, "CTY_Code", "CTY_Name_En");
            ViewData["APT_ALT_APT_Code_1"] = new SelectList(_context.Airport, "APT_Code", "APT_NameEn");
            ViewData["APT_ALT_APT_Code_2"] = new SelectList(_context.Airport, "APT_Code", "APT_NameEn");
            ViewData["APT_ALT_APT_Code_3"] = new SelectList(_context.Airport, "APT_Code", "APT_NameEn");
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

            _context.Attach(Airport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportExists(Airport.APT_Code))
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

        private bool AirportExists(int id)
        {
            return _context.Airport.Any(e => e.APT_Code == id);
        }
    }
}
