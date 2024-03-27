using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnackAttack.Data;
using SnackAttack.Models;

namespace SnackAttack.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public DetailsModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipe
                .Include(r => r.Reviews)
                    .ThenInclude(rv => rv.User)
                .Include(r => r.FavouriteRecipes)
                    .ThenInclude(fr => fr.SnackAttackUser)
                .Include(r => r.MealPlans)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            else 
            {
                Recipe = Recipe;
            }
            return Page();
        }
    }
}
