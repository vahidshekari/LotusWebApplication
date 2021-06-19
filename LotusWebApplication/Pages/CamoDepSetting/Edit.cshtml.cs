using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LotusWebApplication.Models;

namespace LotusWebApplication.Pages.CamoDepSetting
{
    public class EditModel : PageModel
    {
        private readonly LotusWebApplication.Models.AppDBContext _context;

        public EditModel(LotusWebApplication.Models.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LotusWebApplication.Models.CamoDepSetting CamoDepSetting { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CamoDepSetting = await _context.CamoDepSetting.FirstOrDefaultAsync(m => m.CDS_Code == 1);

            if (CamoDepSetting == null)
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

            _context.Attach(CamoDepSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamoDepSettingExists(CamoDepSetting.CDS_Code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }

        private bool CamoDepSettingExists(int id)
        {
            return _context.CamoDepSetting.Any(e => e.CDS_Code == id);
        }
    }
}
