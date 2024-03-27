using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnackAttack.Data;
using SnackAttack.Models;

namespace SnackAttack.Pages.SnackAttackUsers
{
    public class EditModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public EditModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SnackAttackUser SnackAttackUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SnackAttackUser == null)
            {
                return NotFound();
            }

            var snackattackuser =  await _context.SnackAttackUser.FirstOrDefaultAsync(m => m.ID == id);
            if (snackattackuser == null)
            {
                return NotFound();
            }
            SnackAttackUser = snackattackuser;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SnackAttackUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnackAttackUserExists(SnackAttackUser.ID))
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

        private bool SnackAttackUserExists(int id)
        {
          return _context.SnackAttackUser.Any(e => e.ID == id);
        }
    }
}
