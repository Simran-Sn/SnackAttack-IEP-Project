using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackAttack.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixIdentityProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteRecipe",
                table: "FavouriteRecipe");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "MealPlan",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "FavouriteRecipe",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteRecipe",
                table: "FavouriteRecipe",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlan_SnackAttackUserID",
                table: "MealPlan",
                column: "SnackAttackUserID");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteRecipe_SnackAttackUserID",
                table: "FavouriteRecipe",
                column: "SnackAttackUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan");

            migrationBuilder.DropIndex(
                name: "IX_MealPlan_SnackAttackUserID",
                table: "MealPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteRecipe",
                table: "FavouriteRecipe");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteRecipe_SnackAttackUserID",
                table: "FavouriteRecipe");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "MealPlan",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "FavouriteRecipe",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan",
                columns: new[] { "SnackAttackUserID", "Date", "RecipeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteRecipe",
                table: "FavouriteRecipe",
                columns: new[] { "SnackAttackUserID", "RecipeID" });

            migrationBuilder.DropColumn(
    name: "ID",
    table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

        }
    }
}
