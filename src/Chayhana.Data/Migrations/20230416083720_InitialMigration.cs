using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chayhana.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    TotalSoldAmount = table.Column<double>(type: "float", nullable: false),
                    ToTalRemainingAmount = table.Column<double>(type: "float", nullable: false),
                    TotalMoneyOfSoldMeal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    SoldAmount = table.Column<double>(type: "float", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "ToTalRemainingAmount", "TotalAmount", "TotalMoneyOfSoldMeal", "TotalSoldAmount", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 16, 8, 37, 20, 409, DateTimeKind.Utc).AddTicks(9070), "Choyxona", "Osh", 35000m, 25.0, 25.0, 0m, 0.0, 0, null },
                    { 2, new DateTime(2023, 4, 16, 8, 37, 20, 409, DateTimeKind.Utc).AddTicks(9077), "Suyuq", "Lagmon", 20000m, 35.0, 35.0, 0m, 0.0, 0, null },
                    { 3, new DateTime(2023, 4, 16, 8, 37, 20, 409, DateTimeKind.Utc).AddTicks(9081), "Achchiq", "Kimchi", 22000m, 22.0, 22.0, 0m, 0.0, 0, null },
                    { 4, new DateTime(2023, 4, 16, 8, 37, 20, 409, DateTimeKind.Utc).AddTicks(9084), "Gijduvon", "Kabob", 20000m, 20.0, 20.0, 0m, 0.0, 0, null },
                    { 5, new DateTime(2023, 4, 16, 8, 37, 20, 409, DateTimeKind.Utc).AddTicks(9087), "Tovuqli", "Shurva", 18000m, 40.0, 40.0, 0m, 0.0, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoldMeals_MealId",
                table: "SoldMeals",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoldMeals");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
