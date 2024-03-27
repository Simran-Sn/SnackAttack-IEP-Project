using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnackAttack.Data;
using SnackAttack.Models;

namespace SnackAttack.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public IndexModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Review != null)
            {
                Review = await _context.Review
                .Include(r => r.Recipe)
                .Include(r => r.User).ToListAsync();
            }
        }
    }
}
