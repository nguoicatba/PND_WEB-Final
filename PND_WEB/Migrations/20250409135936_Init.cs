using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VnLao",
                table: "tbl_HSCODE",
                newName: "VN_LAO");

            migrationBuilder.RenameColumn(
                name: "VnEaeu",
                table: "tbl_HSCODE",
                newName: "VN_EAEU");

            migrationBuilder.RenameColumn(
                name: "RceptF",
                table: "tbl_HSCODE",
                newName: "RCEPT_F");

            migrationBuilder.RenameColumn(
                name: "RceptE",
                table: "tbl_HSCODE",
                newName: "RCEPT_E");

            migrationBuilder.RenameColumn(
                name: "RceptD",
                table: "tbl_HSCODE",
                newName: "RCEPT_D");

            migrationBuilder.RenameColumn(
                name: "RceptC",
                table: "tbl_HSCODE",
                newName: "RCEPT_C");

            migrationBuilder.RenameColumn(
                name: "RceptB",
                table: "tbl_HSCODE",
                newName: "RCEPT_B");

            migrationBuilder.RenameColumn(
                name: "RceptA",
                table: "tbl_HSCODE",
                newName: "RCEPT_A");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VN_LAO",
                table: "tbl_HSCODE",
                newName: "VnLao");

            migrationBuilder.RenameColumn(
                name: "VN_EAEU",
                table: "tbl_HSCODE",
                newName: "VnEaeu");

            migrationBuilder.RenameColumn(
                name: "RCEPT_F",
                table: "tbl_HSCODE",
                newName: "RceptF");

            migrationBuilder.RenameColumn(
                name: "RCEPT_E",
                table: "tbl_HSCODE",
                newName: "RceptE");

            migrationBuilder.RenameColumn(
                name: "RCEPT_D",
                table: "tbl_HSCODE",
                newName: "RceptD");

            migrationBuilder.RenameColumn(
                name: "RCEPT_C",
                table: "tbl_HSCODE",
                newName: "RceptC");

            migrationBuilder.RenameColumn(
                name: "RCEPT_B",
                table: "tbl_HSCODE",
                newName: "RceptB");

            migrationBuilder.RenameColumn(
                name: "RCEPT_A",
                table: "tbl_HSCODE",
                newName: "RceptA");
        }
    }
}
