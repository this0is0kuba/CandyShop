using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CandyShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kits",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockLevel = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kits", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuildingNumber = table.Column<int>(type: "int", nullable: false),
                    HomeNumber = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sweets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVegan = table.Column<bool>(type: "bit", nullable: false),
                    IsGluten = table.Column<bool>(type: "bit", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockLevel = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sweets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KitsOnly",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    KitID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitsOnly", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KitsOnly_Kits_KitID",
                        column: x => x.KitID,
                        principalTable: "Kits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitsOnly_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitContent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    KitID = table.Column<int>(type: "int", nullable: false),
                    SweetnessID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitContent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KitContent_Kits_KitID",
                        column: x => x.KitID,
                        principalTable: "Kits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitContent_Sweets_SweetnessID",
                        column: x => x.SweetnessID,
                        principalTable: "Sweets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SweetsOnly",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SweetnessID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetsOnly", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SweetsOnly_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SweetsOnly_Sweets_SweetnessID",
                        column: x => x.SweetnessID,
                        principalTable: "Sweets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kits",
                columns: new[] { "ID", "CurrentPrice", "Description", "Discount", "Name", "StockLevel" },
                values: new object[,]
                {
                    { 1, 10m, "Wonderful box of lollipops.", 0, "Lollipop Box", 80 },
                    { 2, 15m, "Wonderful box of gummy candies.", 0, "Gummy Candy Box", 4 }
                });

            migrationBuilder.InsertData(
                table: "Sweets",
                columns: new[] { "ID", "CategoryName", "CurrentPrice", "Description", "Discount", "IsGluten", "IsVegan", "Name", "StockLevel" },
                values: new object[,]
                {
                    { 1, 2, 2m, "Lollipop with an amazing strawberry flavor.", 0, false, true, "Strawberry Lollipop", 100 },
                    { 2, 2, 3m, "Lollipop with an amazing smurf flavor.", 0, true, false, "Smurf Lollipop", 600 },
                    { 3, 2, 2m, "Lollipop with an amazing orange flavor.", 0, false, true, "Orange Lollipop", 100 },
                    { 4, 2, 2m, "Lollipop with an amazing watermelon flavor.", 0, false, true, "Watermelon Lollipop", 100 },
                    { 5, 2, 3m, "Lollipop with an amazing bubblegum flavor.", 0, false, true, "BubbleGum Lollipop", 600 },
                    { 6, 1, 0.5m, "Gummy candy with an amazing bubblegum flavor.", 0, false, true, "BubbleGum Gummy Candy", 1000 },
                    { 7, 1, 0.5m, "Gummy candy with an amazing orange flavor.", 0, false, true, "Orange Gummy Candy", 2000 },
                    { 8, 1, 0.5m, "Gumy candy with an amazing strawberry flavor.", 0, false, true, "Strawberry Gummy Candy", 30 },
                    { 9, 3, 0.5m, "Amazing white chocolate.", 0, false, true, "White Chocolate Candy", 30 },
                    { 10, 3, 0.5m, "Amazing black chocolate.", 0, false, true, "Black Chocolate Candy", 3000 },
                    { 11, 3, 0.5m, "Amazing strawberry chocolate.", 0, false, true, "Strawberry Chocolate Candy", 80 },
                    { 12, 3, 0.5m, "Amazing orange chocolate.", 0, false, true, "Orange Chocolate Candy", 300 },
                    { 13, 3, 1m, "amazing toffee chocolate.", 0, false, true, "Toffee Chocolate Candy", 300 }
                });

            migrationBuilder.InsertData(
                table: "KitContent",
                columns: new[] { "ID", "KitID", "Quantity", "SweetnessID" },
                values: new object[,]
                {
                    { 1, 1, 2, 1 },
                    { 2, 1, 2, 2 },
                    { 3, 1, 2, 3 },
                    { 4, 2, 15, 6 },
                    { 5, 2, 15, 7 },
                    { 6, 2, 15, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitContent_KitID",
                table: "KitContent",
                column: "KitID");

            migrationBuilder.CreateIndex(
                name: "IX_KitContent_SweetnessID",
                table: "KitContent",
                column: "SweetnessID");

            migrationBuilder.CreateIndex(
                name: "IX_KitsOnly_KitID",
                table: "KitsOnly",
                column: "KitID");

            migrationBuilder.CreateIndex(
                name: "IX_KitsOnly_OrderID",
                table: "KitsOnly",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SweetsOnly_OrderID",
                table: "SweetsOnly",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SweetsOnly_SweetnessID",
                table: "SweetsOnly",
                column: "SweetnessID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitContent");

            migrationBuilder.DropTable(
                name: "KitsOnly");

            migrationBuilder.DropTable(
                name: "SweetsOnly");

            migrationBuilder.DropTable(
                name: "Kits");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sweets");
        }
    }
}
