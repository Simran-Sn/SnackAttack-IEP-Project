using System.ComponentModel.DataAnnotations;

namespace SnackAttack.Models
{
    public class FavouriteRecipe
    {

        [Required(ErrorMessage = "Date is required.")]

        public int ID { get; set; }

        public int SnackAttackUserID { get; set; }
        public SnackAttackUser SnackAttackUser { get; set; }

        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }

}

