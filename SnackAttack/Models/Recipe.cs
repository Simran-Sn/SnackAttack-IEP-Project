using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackAttack.Models
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }


        [StringLength(100, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, MinimumLength = 1)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Ingredients are required.")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Directions are required.")]
        public string Directions { get; set; }

        [Required(ErrorMessage = "Cost is required.")]
        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Estimated Cost")]
        public decimal TotalEstimatedCost { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [RegularExpression("^(?i)(vegan|vegetarian|pescatarian|omnivore)$", ErrorMessage = "Category must be Vegan, Vegetarian, Pescatarian, or Omnivore")]
        [Display(Description = "Category must be Vegan, Vegetarian, Pescatarian, or Omnivore")]

        public string Category { get; set; }


        public ICollection<Review> Reviews { get; set; }
        public ICollection<FavouriteRecipe> FavouriteRecipes { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; }
    }
}
