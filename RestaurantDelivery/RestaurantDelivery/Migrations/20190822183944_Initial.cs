using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantDelivery.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    IdRestaurant = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    Cuisine = table.Column<string>(maxLength: 30, nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.IdRestaurant);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    IdMenuItem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdRestaurant = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ItemDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ItemPrice = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.IdMenuItem);
                    table.ForeignKey(
                        name: "FK_MenuItems_Restaurants",
                        column: x => x.IdRestaurant,
                        principalTable: "Restaurant",
                        principalColumn: "IdRestaurant",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false),
                    IdRestaurant = table.Column<int>(nullable: false),
                    IdMenuItem = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    CustomerAddress = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    OrderNetAmount = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    OrderTax = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    OrderGrossAmount = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    CustomerNotes = table.Column<string>(unicode: false, maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_MenuItems",
                        column: x => x.IdMenuItem,
                        principalTable: "MenuItem",
                        principalColumn: "IdMenuItem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Restaurants",
                        column: x => x.IdRestaurant,
                        principalTable: "Restaurant",
                        principalColumn: "IdRestaurant",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_IdRestaurant",
                table: "MenuItem",
                column: "IdRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdMenuItem",
                table: "Order",
                column: "IdMenuItem");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdRestaurant",
                table: "Order",
                column: "IdRestaurant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
