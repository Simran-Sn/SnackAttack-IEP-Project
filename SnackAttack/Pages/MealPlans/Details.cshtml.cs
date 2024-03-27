using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnackAttack.Data;
using SnackAttack.Models;

namespace SnackAttack.Pages.MealPlans
{
    public class DetailsModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public DetailsModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public MealPlan MealPlan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MealPlan == null)
            {
                return NotFound();
            }

            MealPlan = await _context.MealPlan
                .Include(mp => mp.Recipe)
                .Include(mp => mp.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (MealPlan == null)
            {
                return NotFound();
            }
            else 
            {
                MealPlan = MealPlan;
            }
            return Page();
        }
    }
}
