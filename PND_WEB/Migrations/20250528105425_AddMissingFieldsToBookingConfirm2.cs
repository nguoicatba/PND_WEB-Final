using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingFieldsToBookingConfirm2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNEE",
                table: "tbl_BOOKING_CONFIRM",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shipper",
                table: "tbl_BOOKING_CONFIRM",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNEE",
                table: "tbl_BOOKING_CONFIRM");

            migrationBuilder.DropColumn(
                name: "Shipper",
                table: "tbl_BOOKING_CONFIRM");
        }
    }
}
