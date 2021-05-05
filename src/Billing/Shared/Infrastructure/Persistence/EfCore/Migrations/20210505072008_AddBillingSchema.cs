using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.Shared.Infrastructure.Persistence.EfCore.Migrations
{
    public partial class AddBillingSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Billing");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Billing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Identifier_TaxIdentifier = table.Column<string>(nullable: true),
                    Identifier_Value = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Billing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FriendlyName = table.Column<string>(nullable: true),
                    Price_Value = table.Column<decimal>(nullable: true),
                    Price_Currency = table.Column<string>(nullable: true),
                    StockQuantity_Value = table.Column<decimal>(nullable: true),
                    StockQuantity_UnitMeasurement = table.Column<string>(nullable: true),
                    Tax_Value = table.Column<decimal>(nullable: true),
                    Tax_Currency = table.Column<string>(nullable: true),
                    TaxDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "Billing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerDetails_Age = table.Column<int>(nullable: true),
                    CustomerDetails_Identifier_TaxIdentifier = table.Column<string>(nullable: true),
                    CustomerDetails_Identifier_Value = table.Column<string>(nullable: true),
                    CustomerDetails_Name = table.Column<string>(nullable: true),
                    CustomerDetails_CustomerId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    TotalReceived_Value = table.Column<decimal>(nullable: true),
                    TotalReceived_Currency = table.Column<string>(nullable: true),
                    TotalItems = table.Column<int>(nullable: false),
                    TotalPrice_Value = table.Column<decimal>(nullable: true),
                    TotalPrice_Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerDetails_CustomerId",
                        column: x => x.CustomerDetails_CustomerId,
                        principalSchema: "Billing",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductStockHistories",
                schema: "Billing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    QuantityAdjustment_Value = table.Column<decimal>(nullable: true),
                    QuantityAdjustment_UnitMeasurement = table.Column<string>(nullable: true),
                    StockQuantity_Value = table.Column<decimal>(nullable: true),
                    StockQuantity_UnitMeasurement = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStockHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStockHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Billing",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                schema: "Billing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity_Value = table.Column<decimal>(nullable: true),
                    Quantity_UnitMeasurement = table.Column<string>(nullable: true),
                    TaxDescription = table.Column<string>(nullable: true),
                    TotalPrice_Value = table.Column<decimal>(nullable: true),
                    TotalPrice_Currency = table.Column<string>(nullable: true),
                    UnitPrice_Value = table.Column<decimal>(nullable: true),
                    UnitPrice_Currency = table.Column<string>(nullable: true),
                    UnitTax_Value = table.Column<decimal>(nullable: true),
                    UnitTax_Currency = table.Column<string>(nullable: true),
                    InvoiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Billing",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Billing",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                schema: "Billing",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ProductId",
                schema: "Billing",
                table: "InvoiceItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerDetails_CustomerId",
                schema: "Billing",
                table: "Invoices",
                column: "CustomerDetails_CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockHistories_ProductId",
                schema: "Billing",
                table: "ProductStockHistories",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItems",
                schema: "Billing");

            migrationBuilder.DropTable(
                name: "ProductStockHistories",
                schema: "Billing");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "Billing");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Billing");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Billing");
        }
    }
}
