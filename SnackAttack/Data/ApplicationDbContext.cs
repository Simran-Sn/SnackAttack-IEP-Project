using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnackAttack.Models;

namespace SnackAttack.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SnackAttack.Models.SnackAttackUser> SnackAttackUser { get; set; }
        public DbSet<SnackAttack.Models.Recipe> Recipe { get; set; }
        public DbSet<SnackAttack.Models.Review> Review { get; set; }
        public DbSet<SnackAttack.Models.FavouriteRecipe> FavouriteRecipe { get; set; }
        public DbSet<SnackAttack.Models.MealPlan> MealPlan { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SnackAttack.Models.SnackAttackUser>().ToTable("SnackAttackUser");
            modelBuilder.Entity<SnackAttack.Models.Recipe>().ToTable("Recipe");
            modelBuilder.Entity<SnackAttack.Models.Review>().ToTable("Review");
            modelBuilder.Entity<SnackAttack.Models.FavouriteRecipe>().ToTable("FavouriteRecipe");
            modelBuilder.Entity<SnackAttack.Models.MealPlan>().ToTable("MealPlan");
        }


    }
}