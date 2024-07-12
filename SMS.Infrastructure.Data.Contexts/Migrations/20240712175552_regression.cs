using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Data.Contexts.Migrations
{
    public partial class regression : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchaseorder",
                schema: "itemization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PODate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchaseorder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchaseorder_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PurchasingExpenses",
                schema: "itemization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaiedAmount = table.Column<double>(type: "float", nullable: false),
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasingExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasingExpenses_Purchaseorder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalSchema: "itemization",
                        principalTable: "Purchaseorder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PurchasingExpenses_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchaseorder_VendorId",
                schema: "itemization",
                table: "Purchaseorder",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingExpenses_PurchaseOrderId",
                schema: "itemization",
                table: "PurchasingExpenses",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingExpenses_VendorId",
                schema: "itemization",
                table: "PurchasingExpenses",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasingExpenses",
                schema: "itemization");

            migrationBuilder.DropTable(
                name: "Purchaseorder",
                schema: "itemization");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
