using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    phoneNumber = table.Column<long>(nullable: false),
                    creditCardNumber = table.Column<long>(nullable: false),
                    expDate = table.Column<string>(nullable: false),
                    cvc = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    delivery = table.Column<bool>(nullable: false),
                    status = table.Column<string>(nullable: false),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    size = table.Column<string>(nullable: false),
                    sauce = table.Column<string>(nullable: false),
                    crust = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    pizzaId = table.Column<int>(nullable: false),
                    toppingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
