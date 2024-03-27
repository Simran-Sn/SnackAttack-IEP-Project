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
    public class DeleteModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public DeleteModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

            public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MealPlan == null)
            {
                return NotFound();
            }
            var mealplan = await _context.MealPlan.FindAsync(id);

            if (mealplan != null)
            {
                MealPlan = mealplan;
                _context.MealPlan.Remove(MealPlan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
