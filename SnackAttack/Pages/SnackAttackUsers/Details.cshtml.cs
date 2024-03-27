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
    public class DetailsModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public DetailsModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public SnackAttackUser SnackAttackUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SnackAttackUser == null)
            {
                return NotFound();
            }


            SnackAttackUser = await _context.SnackAttackUser
                .Include(s => s.Recipes)
                .Include(s => s.Reviews)
                    .ThenInclude(r => r.Recipe)
                .Include(s => s.FavouriteRecipes)
                    .ThenInclude(f => f.Recipe)
                .Include(s => s.MealPlans)
                    .ThenInclude(mp => mp.Recipe)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (SnackAttackUser == null)
            {
                return NotFound();
            }
            else 
            {
                SnackAttackUser = SnackAttackUser;
            }
            return Page();
        }
    }
}
