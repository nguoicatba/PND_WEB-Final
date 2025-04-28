using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init284 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TT",
                table: "TblTuttsPhi");

            migrationBuilder.DropColumn(
                name: "TU",
                table: "TblTuttsPhi");

            migrationBuilder.DropColumn(
                name: "Buy",
                table: "tbl_CHARGES");

            migrationBuilder.DropColumn(
                name: "Cont",
                table: "tbl_CHARGES");

            migrationBuilder.DropColumn(
                name: "Sell",
                table: "tbl_CHARGES");

            migrationBuilder.AddColumn<bool>(
                name: "TT",
                table: "tbl_TUTT",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TU",
                table: "tbl_TUTT",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Buy",
                table: "tbl_INVOICE",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cont",
                table: "tbl_INVOICE",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sell",
                table: "tbl_INVOICE",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TT",
                table: "tbl_TUTT");

            migrationBuilder.DropColumn(
                name: "TU",
                table: "tbl_TUTT");

            migrationBuilder.DropColumn(
                name: "Buy",
                table: "tbl_INVOICE");

            migrationBuilder.DropColumn(
                name: "Cont",
                table: "tbl_INVOICE");

            migrationBuilder.DropColumn(
                name: "Sell",
                table: "tbl_INVOICE");

            migrationBuilder.AddColumn<bool>(
                name: "TT",
                table: "TblTuttsPhi",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TU",
                table: "TblTuttsPhi",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Buy",
                table: "tbl_CHARGES",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cont",
                table: "tbl_CHARGES",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sell",
                table: "tbl_CHARGES",
                type: "bit",
                nullable: true);
        }
    }
}
