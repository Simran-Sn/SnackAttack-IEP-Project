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
    public class IndexModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public IndexModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FavouriteRecipe> FavouriteRecipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FavouriteRecipe != null)
            {
                FavouriteRecipe = await _context.FavouriteRecipe
                .Include(f => f.Recipe)
                .Include(f => f.SnackAttackUser).ToListAsync();
            }
        }
    }
}
