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
    public class IndexModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public IndexModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MealPlan> MealPlan { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MealPlan != null)
            {
                MealPlan = await _context.MealPlan
                .Include(m => m.Recipe)
                .Include(m => m.User).ToListAsync();
            }
        }
    }
}
