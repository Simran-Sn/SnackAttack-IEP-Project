using System.ComponentModel.DataAnnotations;

namespace SnackAttack.Models
{
    public class SnackAttackUser
    {
        public int ID { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Premium Account")]
        public bool IsPremium { get; set; }

        public ICollection<FavouriteRecipe> FavouriteRecipes { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; }

    }
}
