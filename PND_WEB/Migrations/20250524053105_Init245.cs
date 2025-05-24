using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init245 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_INVOICE_tbl_SUPPLIER_Supplier_ID",
                table: "tbl_INVOICE");

            migrationBuilder.AlterColumn<double>(
                name: "GrossWeight",
                table: "TblConths",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Cmb",
                table: "TblConths",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Supplier_ID",
                table: "tbl_INVOICE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "tbl_INVOICE",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_INVOICE_tbl_SUPPLIER_Supplier_ID",
                table: "tbl_INVOICE",
                column: "Supplier_ID",
                principalTable: "tbl_SUPPLIER",
                principalColumn: "Supplier_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_INVOICE_tbl_SUPPLIER_Supplier_ID",
                table: "tbl_INVOICE");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "tbl_INVOICE");

            migrationBuilder.AlterColumn<double>(
                name: "GrossWeight",
                table: "TblConths",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Cmb",
                table: "TblConths",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Supplier_ID",
                table: "tbl_INVOICE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_INVOICE_tbl_SUPPLIER_Supplier_ID",
                table: "tbl_INVOICE",
                column: "Supplier_ID",
                principalTable: "tbl_SUPPLIER",
                principalColumn: "Supplier_ID");
        }
    }
}
