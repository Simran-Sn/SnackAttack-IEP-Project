using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnackAttack.Data;
using SnackAttack.Models;

namespace SnackAttack.Pages.SnackAttackUsers
{
    public class DeleteModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public DeleteModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SnackAttackUser SnackAttackUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SnackAttackUser == null)
            {
                return NotFound();
            }

            var snackattackuser = await _context.SnackAttackUser.FirstOrDefaultAsync(m => m.ID == id);

            if (snackattackuser == null)
            {
                return NotFound();
            }
            else 
            {
                SnackAttackUser = snackattackuser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SnackAttackUser == null)
            {
                return NotFound();
            }
            var snackattackuser = await _context.SnackAttackUser.FindAsync(id);

            if (snackattackuser != null)
            {
                SnackAttackUser = snackattackuser;
                _context.SnackAttackUser.Remove(SnackAttackUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
