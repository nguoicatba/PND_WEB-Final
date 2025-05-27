using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init275 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_BOOKING_CONFIRM",
                columns: table => new
                {
                    Booking_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Customer_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Booking_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Good_Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ETD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    POL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    POD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Vessel_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Container_Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Container_Quantity = table.Column<int>(type: "int", nullable: true),
                    Flight_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Airline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Package_Quantity = table.Column<int>(type: "int", nullable: true),
                    Gross_Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Chargeable_Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cargo_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_BOOKING_CONFIRM", x => x.Booking_ID);
                    table.ForeignKey(
                        name: "FK_tbl_BOOKING_CONFIRM_tbl_CUSTOMER_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "tbl_CUSTOMER",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BOOKING_CONFIRM_Customer_ID",
                table: "tbl_BOOKING_CONFIRM",
                column: "Customer_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_BOOKING_CONFIRM");
        }
    }
}
