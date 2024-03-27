﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnackAttack.Data;
using SnackAttack.Models;

namespace SnackAttack.Pages.FavouriteRecipes
{
    public class EditModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;

        public EditModel(SnackAttack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FavouriteRecipe FavouriteRecipe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FavouriteRecipe == null)
            {
                return NotFound();
            }

            var favouriterecipe =  await _context.FavouriteRecipe.FirstOrDefaultAsync(m => m.ID == id);
            if (favouriterecipe == null)
            {
                return NotFound();
            }
            FavouriteRecipe = favouriterecipe;
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

            _context.Attach(FavouriteRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouriteRecipeExists(FavouriteRecipe.ID))
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

        private bool FavouriteRecipeExists(int id)
        {
          return _context.FavouriteRecipe.Any(e => e.ID == id);
        }
    }
}
