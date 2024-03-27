using System.ComponentModel.DataAnnotations;

namespace SnackAttack.Models
{
    public class MealPlan
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }


        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }

        public int SnackAttackUserID { get; set; }
        public SnackAttackUser User { get; set; }

    }
}
