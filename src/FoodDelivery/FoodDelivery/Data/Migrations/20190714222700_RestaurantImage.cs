using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDelivery.Data.Migrations
{
    public partial class RestaurantImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Customer",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Password = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Cust__DB43864AD52E05A5", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "tbl_OrderStatus",
                columns: table => new
                {
                    IdOrderStatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Orde__CFDB504663CAB332", x => x.IdOrderStatus);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Restaurant",
                columns: table => new
                {
                    IdRestaurant = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Cuisine = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Rest__311D1D13132FA81F", x => x.IdRestaurant);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DeliveryAddress",
                columns: table => new
                {
                    IdAddress = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCustomer = table.Column<int>(nullable: false),
                    Street = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Deli__F1CFF37FF175AFF1", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK_DeliveryAddress_Customer",
                        column: x => x.IdCustomer,
                        principalTable: "tbl_Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PaymentMethod",
                columns: table => new
                {
                    IdPaymentMethod = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCustomer = table.Column<int>(nullable: false),
                    CardNumber = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SecurityCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Paym__92CFFF9611484FED", x => x.IdPaymentMethod);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_Customer",
                        column: x => x.IdCustomer,
                        principalTable: "tbl_Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RestaurantMenu",
                columns: table => new
                {
                    IdRestaurantMenu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdRestaurant = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    MenuType = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Rest__6861EAA44F8D8670", x => x.IdRestaurantMenu);
                    table.ForeignKey(
                        name: "FK_RestaurantMenu_Restaurant",
                        column: x => x.IdRestaurant,
                        principalTable: "tbl_Restaurant",
                        principalColumn: "IdRestaurant",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCustomer = table.Column<int>(nullable: false),
                    IdAddress = table.Column<int>(nullable: false),
                    IdPaymentMethod = table.Column<int>(nullable: false),
                    IdRestaurant = table.Column<int>(nullable: false),
                    IdOrderStatus = table.Column<int>(nullable: false),
                    OrderNetAmount = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    OrderTax = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    OrderGrossAmount = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    CustomerNotes = table.Column<string>(unicode: false, maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Orde__C38F3009BDFD1FDD", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_DeliveryAddress",
                        column: x => x.IdAddress,
                        principalTable: "tbl_DeliveryAddress",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Customer",
                        column: x => x.IdCustomer,
                        principalTable: "tbl_Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Status",
                        column: x => x.IdOrderStatus,
                        principalTable: "tbl_OrderStatus",
                        principalColumn: "IdOrderStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_PaymentMethod",
                        column: x => x.IdPaymentMethod,
                        principalTable: "tbl_PaymentMethod",
                        principalColumn: "IdPaymentMethod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Restaurant",
                        column: x => x.IdRestaurant,
                        principalTable: "tbl_Restaurant",
                        principalColumn: "IdRestaurant",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RestaurantMenuItem",
                columns: table => new
                {
                    IdRestaurantMenuItem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdRestaurantMenu = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ItemDescription = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ItemPrice = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Rest__97544FC9D2184FB8", x => x.IdRestaurantMenuItem);
                    table.ForeignKey(
                        name: "FK_RestaurantMenuItem_RestaurantMenu",
                        column: x => x.IdRestaurantMenu,
                        principalTable: "tbl_RestaurantMenu",
                        principalColumn: "IdRestaurantMenu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_OrderItem",
                columns: table => new
                {
                    IdOrderItem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOrder = table.Column<int>(nullable: false),
                    IdRestaurantMenuItem = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    PricePerUnity = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Orde__65E8C2F3807E9B8E", x => x.IdOrderItem);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.IdOrder,
                        principalTable: "tbl_Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DeliveryAddress_IdCustomer",
                table: "tbl_DeliveryAddress",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Order_IdAddress",
                table: "tbl_Order",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Order_IdCustomer",
                table: "tbl_Order",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Order_IdOrderStatus",
                table: "tbl_Order",
                column: "IdOrderStatus");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Order_IdPaymentMethod",
                table: "tbl_Order",
                column: "IdPaymentMethod");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Order_IdRestaurant",
                table: "tbl_Order",
                column: "IdRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_OrderItem_IdOrder",
                table: "tbl_OrderItem",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PaymentMethod_IdCustomer",
                table: "tbl_PaymentMethod",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RestaurantMenu_IdRestaurant",
                table: "tbl_RestaurantMenu",
                column: "IdRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RestaurantMenuItem_IdRestaurantMenu",
                table: "tbl_RestaurantMenuItem",
                column: "IdRestaurantMenu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_OrderItem");

            migrationBuilder.DropTable(
                name: "tbl_RestaurantMenuItem");

            migrationBuilder.DropTable(
                name: "tbl_Order");

            migrationBuilder.DropTable(
                name: "tbl_RestaurantMenu");

            migrationBuilder.DropTable(
                name: "tbl_DeliveryAddress");

            migrationBuilder.DropTable(
                name: "tbl_OrderStatus");

            migrationBuilder.DropTable(
                name: "tbl_PaymentMethod");

            migrationBuilder.DropTable(
                name: "tbl_Restaurant");

            migrationBuilder.DropTable(
                name: "tbl_Customer");
        }
    }
}
