using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnackAttack.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSAModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SnackAttackUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackAttackUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Directions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalEstimatedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SnackAttackUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recipe_SnackAttackUser_SnackAttackUserID",
                        column: x => x.SnackAttackUserID,
                        principalTable: "SnackAttackUser",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FavouriteRecipe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SnackAttackUserID = table.Column<int>(type: "int", nullable: false),
                    RecipeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteRecipe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FavouriteRecipe_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteRecipe_SnackAttackUser_SnackAttackUserID",
                        column: x => x.SnackAttackUserID,
                        principalTable: "SnackAttackUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealPlan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipeID = table.Column<int>(type: "int", nullable: false),
                    SnackAttackUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MealPlan_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealPlan_SnackAttackUser_SnackAttackUserID",
                        column: x => x.SnackAttackUserID,
                        principalTable: "SnackAttackUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RecipeID = table.Column<int>(type: "int", nullable: false),
                    SnackAttackUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Review_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_SnackAttackUser_SnackAttackUserID",
                        column: x => x.SnackAttackUserID,
                        principalTable: "SnackAttackUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteRecipe_RecipeID",
                table: "FavouriteRecipe",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteRecipe_SnackAttackUserID",
                table: "FavouriteRecipe",
                column: "SnackAttackUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlan_RecipeID",
                table: "MealPlan",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlan_SnackAttackUserID",
                table: "MealPlan",
                column: "SnackAttackUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_SnackAttackUserID",
                table: "Recipe",
                column: "SnackAttackUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_RecipeID",
                table: "Review",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_SnackAttackUserID",
                table: "Review",
                column: "SnackAttackUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteRecipe");

            migrationBuilder.DropTable(
                name: "MealPlan");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "SnackAttackUser");
        }
    }
}
