using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingFieldsToBookingConfirm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "tbl_BOOKING_CONFIRM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PIC_company",
                table: "tbl_BOOKING_CONFIRM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quotation_Id",
                table: "tbl_BOOKING_CONFIRM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffName",
                table: "tbl_BOOKING_CONFIRM",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "tbl_BOOKING_CONFIRM");

            migrationBuilder.DropColumn(
                name: "PIC_company",
                table: "tbl_BOOKING_CONFIRM");

            migrationBuilder.DropColumn(
                name: "Quotation_Id",
                table: "tbl_BOOKING_CONFIRM");

            migrationBuilder.DropColumn(
                name: "StaffName",
                table: "tbl_BOOKING_CONFIRM");
        }
    }
}
