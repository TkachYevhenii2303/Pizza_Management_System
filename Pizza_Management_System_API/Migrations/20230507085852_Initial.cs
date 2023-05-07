using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza_Management_System_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sauces",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sauce_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_vegan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Topping_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pizza_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SauceID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pizza_Sauces_SauceID",
                        column: x => x.SauceID,
                        principalTable: "Sauces",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    PizzasID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToppingsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.PizzasID, x.ToppingsID });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizza_PizzasID",
                        column: x => x.PizzasID,
                        principalTable: "Pizza",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Toppings_ToppingsID",
                        column: x => x.ToppingsID,
                        principalTable: "Toppings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SauceID",
                table: "Pizza",
                column: "SauceID");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingsID",
                table: "PizzaTopping",
                column: "ToppingsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Sauces");
        }
    }
}
