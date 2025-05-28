using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init285 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_HBL_CHARGES",
                columns: table => new
                {
                    Charge_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Supplier_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Customer_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ser_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ser_Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ser_Quantity = table.Column<float>(type: "real", nullable: true),
                    Ser_Price = table.Column<float>(type: "real", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Exchange_rate = table.Column<float>(type: "real", nullable: true),
                    Ser_VAT = table.Column<float>(type: "real", nullable: true),
                    M_VAT = table.Column<float>(type: "real", nullable: true),
                    Checked = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNo = table.Column<string>(name: "Invoice No", type: "nvarchar(max)", nullable: true),
                    Buy = table.Column<bool>(type: "bit", nullable: true),
                    Sell = table.Column<bool>(type: "bit", nullable: true),
                    Cont = table.Column<bool>(type: "bit", nullable: true),
                    Behalf = table.Column<bool>(type: "bit", nullable: true),
                    HBL_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HBL_CHARGES", x => x.Charge_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_HBL_CHARGES");
        }
    }
}
