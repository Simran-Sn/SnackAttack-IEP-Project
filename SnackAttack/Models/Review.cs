using System.ComponentModel.DataAnnotations;

namespace SnackAttack.Models
{
    public class Review
    {
        public int ID { get; set; }

        [Range(1, 5)]
        [Display(Description = "Rating must be between 1 and 5")]
        public int Rating { get; set; }


        [StringLength(1000, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Comment { get; set; }


        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }

        public int SnackAttackUserID { get; set; }
        public SnackAttackUser User { get; set; }



    }
}
