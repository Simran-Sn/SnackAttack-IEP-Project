using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SnackAttack.Data;
using SnackAttack.Models;

namespace SnackAttack.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly SnackAttack.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(SnackAttack.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public PaginatedList<Recipe> Recipes { get; set; }

        public string NameSort { get; set; }
        public string CategorySort { get; set; }
        public string CostSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        public SelectList CategoryList { get; set; }

        public int RecipeID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserId { get; set; }


        public IList<Recipe> RecipeReview { get; set; }
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, string categoryFilter, int? id)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CategorySort = sortOrder == "Category" ? "category_desc" : "Category";
            CostSort = sortOrder == "Cost" ? "cost_desc" : "Cost";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Recipe> recipeIQ = from r in _context.Recipe.AsQueryable()
                                          select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipeIQ = recipeIQ.Where(r => r.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(categoryFilter))
            {
                recipeIQ = recipeIQ.Where(r => r.Category == categoryFilter);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    recipeIQ = recipeIQ.OrderByDescending(r => r.Name);
                    break;
                case "Category":
                    recipeIQ = recipeIQ.OrderBy(r => r.Category);
                    break;
                case "category_desc":
                    recipeIQ = recipeIQ.OrderByDescending(r => r.Category);
                    break;
                case "Cost":
                    recipeIQ = recipeIQ.OrderBy(r => r.TotalEstimatedCost);
                    break;
                case "cost_desc":
                    recipeIQ = recipeIQ.OrderByDescending(r => r.TotalEstimatedCost);
                    break;
                default:
                    recipeIQ = recipeIQ.OrderBy(r => r.Name);
                    break;
            }

            int pageSize = Configuration.GetValue<int>("PageSize", 5);

            Recipes = await PaginatedList<Recipe>.CreateAsync(recipeIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            CategoryList = new SelectList(await _context.Recipe
                .Select(r => r.Category)
                .Distinct()
                .ToListAsync());

            if (id != null)
            {
                RecipeID = id.Value;
                RecipeReview = await _context.Recipe
                    .Include(r => r.Reviews)
                    .AsNoTracking()
                    .Where(m => m.ID == id.Value)
                    .ToListAsync();

            }
        }
    }
}
