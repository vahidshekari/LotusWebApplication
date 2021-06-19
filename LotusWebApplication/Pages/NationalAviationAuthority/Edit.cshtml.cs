using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.NationalAviationAuthority
{
    public class EditModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public EditModel(LotusWebApplication.Models.AppDBContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NationalAviationAuthority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalAviationAuthorityExists(NationalAviationAuthority.NAA_Code))
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

        private bool NationalAviationAuthorityExists(int id)
        {
            return _context.NationalAviationAuthority.Any(e => e.NAA_Code == id);
        }
    }
}
