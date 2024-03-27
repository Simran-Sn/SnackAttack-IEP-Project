﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public DetailsModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Review Review { get; set; }

public async Task<IActionResult> OnGetAsync(int? id)
{
    if (id == null || _context.Review == null)
    {
        return NotFound();
    }

    var review = await _context.Review
        .Include(r => r.User)
        .Include(r => r.Recipe)
        .FirstOrDefaultAsync(m => m.ID == id);

    if (review == null)
    {
        return NotFound();
    }
    else 
    {
        Review = review;
    }
    return Page();
}

    }
}
