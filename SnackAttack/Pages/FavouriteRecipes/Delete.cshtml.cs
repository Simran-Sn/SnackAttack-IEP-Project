using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnackAttack.Data;
using SnackAttack.Models;

namespace SnackAttack.Pages.FavouriteRecipes
{
    public class DeleteModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public DeleteModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FavouriteRecipe FavouriteRecipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FavouriteRecipe == null)
            {
                return NotFound();
            }

            FavouriteRecipe = await _context.FavouriteRecipe
                .Include(fr => fr.Recipe)
                .Include(fr => fr.SnackAttackUser)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (FavouriteRecipe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FavouriteRecipe == null)
            {
                return NotFound();
            }
            var favouriterecipe = await _context.FavouriteRecipe.FindAsync(id);

            if (favouriterecipe != null)
            {
                FavouriteRecipe = favouriterecipe;
                _context.FavouriteRecipe.Remove(FavouriteRecipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
