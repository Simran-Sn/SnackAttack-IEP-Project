using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SnackAttack.Data;
using SnackAttack.Models;

namespace SnackAttack.Pages.FavouriteRecipes
{
    public class CreateModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public CreateModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RecipeID"] = new SelectList(_context.Recipe, "ID", "Name");
        ViewData["SnackAttackUserID"] = new SelectList(_context.SnackAttackUser, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public FavouriteRecipe FavouriteRecipe { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FavouriteRecipe.Add(FavouriteRecipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
