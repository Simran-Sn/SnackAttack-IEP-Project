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
    public class IndexModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public IndexModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SnackAttackUser> SnackAttackUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SnackAttackUser != null)
            {
                SnackAttackUser = await _context.SnackAttackUser.ToListAsync();
            }
        }
    }
}
