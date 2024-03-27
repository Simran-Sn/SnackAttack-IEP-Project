using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SnackAttack.Pages.About
{
    public class IndexModel : PageModel
    {
        public string ProjectDescription { get; set; }
        public Founder[] Founders { get; set; }

        public void OnGet()
        {
            // Set the project description
            ProjectDescription = "SnackAttack is a recipe sharing platform for university students.";

            // Set the founders
            Founders = new Founder[]
            {
                new Founder { Name = "Simran", ImageUrl = "simran.jpg", Bio = "Simran is a computer science student with a passion for cooking and creating new recipes." },
                new Founder { Name = "Nonyem", ImageUrl = "nonyem.jpg", Bio = "Nonyem is a food blogger and nutritionist who loves to experiment with healthy recipes." },
                new Founder { Name = "Nency", ImageUrl = "nency.jpg", Bio = "Nency is a culinary arts student who specializes in baking and pastry." }
            };
        }
    }

    public class Founder
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
    }
}