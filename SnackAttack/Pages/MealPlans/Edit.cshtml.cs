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

namespace SnackAttack.Pages.MealPlans
{
    public class EditModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public EditModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MealPlan MealPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MealPlan == null)
            {
                return NotFound();
            }

            var mealplan =  await _context.MealPlan.FirstOrDefaultAsync(m => m.ID == id);
            if (mealplan == null)
            {
                return NotFound();
            }
            MealPlan = mealplan;
           ViewData["RecipeName"] = new SelectList(_context.Recipe, "ID", "Name");
            ViewData["SnackAttackUserID"] = new SelectList(_context.SnackAttackUser, "ID", "ID");
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

            _context.Attach(MealPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealPlanExists(MealPlan.ID))
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

        private bool MealPlanExists(int id)
        {
          return _context.MealPlan.Any(e => e.ID == id);
        }
    }
}
