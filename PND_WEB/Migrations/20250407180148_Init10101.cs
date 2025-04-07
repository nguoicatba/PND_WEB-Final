using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init10101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblTuttsPhi_TblTutts_SoTuttNavigationSoTutt",
                table: "TblTuttsPhi");

            migrationBuilder.DropIndex(
                name: "IX_TblTuttsPhi_SoTuttNavigationSoTutt",
                table: "TblTuttsPhi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblTutts",
                table: "TblTutts");

            migrationBuilder.DropColumn(
                name: "SoTuttNavigationSoTutt",
                table: "TblTuttsPhi");

            migrationBuilder.RenameTable(
                name: "TblTutts",
                newName: "tbl_TUTT");

            migrationBuilder.RenameColumn(
                name: "Tu",
                table: "TblTuttsPhi",
                newName: "TU");

            migrationBuilder.RenameColumn(
                name: "Tt",
                table: "TblTuttsPhi",
                newName: "TT");

            migrationBuilder.RenameColumn(
                name: "SoTutt",
                table: "TblTuttsPhi",
                newName: "SoTUTT");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TblTuttsPhi",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "NghiChu",
                table: "TblTuttsPhi",
                newName: "GhiChu");

            migrationBuilder.RenameColumn(
                name: "NhanvienTutt",
                table: "tbl_TUTT",
                newName: "NhanvienTUTT");

            migrationBuilder.RenameColumn(
                name: "Ketoan",
                table: "tbl_TUTT",
                newName: "ketoan");

            migrationBuilder.RenameColumn(
                name: "Ceo",
                table: "tbl_TUTT",
                newName: "ceo");

            migrationBuilder.RenameColumn(
                name: "SoTutt",
                table: "tbl_TUTT",
                newName: "SoTUTT");

            migrationBuilder.RenameColumn(
                name: "NoiDung",
                table: "tbl_TUTT",
                newName: "Noi_dung");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "tbl_TUTT",
                newName: "Ghi_chu");

            migrationBuilder.AlterColumn<string>(
                name: "TenPhi",
                table: "TblTuttsPhi",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoTUTT",
                table: "TblTuttsPhi",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoHoaDon",
                table: "TblTuttsPhi",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "TblTuttsPhi",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NhanvienTUTT",
                table: "tbl_TUTT",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoTUTT",
                table: "tbl_TUTT",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Noi_dung",
                table: "tbl_TUTT",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ghi_chu",
                table: "tbl_TUTT",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_TUTT",
                table: "tbl_TUTT",
                column: "SoTUTT");

            migrationBuilder.CreateIndex(
                name: "IX_TblTuttsPhi_SoTUTT",
                table: "TblTuttsPhi",
                column: "SoTUTT");

            migrationBuilder.AddForeignKey(
                name: "FK_TblTuttsPhi_tbl_TUTT_SoTUTT",
                table: "TblTuttsPhi",
                column: "SoTUTT",
                principalTable: "tbl_TUTT",
                principalColumn: "SoTUTT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblTuttsPhi_tbl_TUTT_SoTUTT",
                table: "TblTuttsPhi");

            migrationBuilder.DropIndex(
                name: "IX_TblTuttsPhi_SoTUTT",
                table: "TblTuttsPhi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_TUTT",
                table: "tbl_TUTT");

            migrationBuilder.RenameTable(
                name: "tbl_TUTT",
                newName: "TblTutts");

            migrationBuilder.RenameColumn(
                name: "TU",
                table: "TblTuttsPhi",
                newName: "Tu");

            migrationBuilder.RenameColumn(
                name: "TT",
                table: "TblTuttsPhi",
                newName: "Tt");

            migrationBuilder.RenameColumn(
                name: "SoTUTT",
                table: "TblTuttsPhi",
                newName: "SoTutt");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TblTuttsPhi",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "TblTuttsPhi",
                newName: "NghiChu");

            migrationBuilder.RenameColumn(
                name: "ketoan",
                table: "TblTutts",
                newName: "Ketoan");

            migrationBuilder.RenameColumn(
                name: "ceo",
                table: "TblTutts",
                newName: "Ceo");

            migrationBuilder.RenameColumn(
                name: "NhanvienTUTT",
                table: "TblTutts",
                newName: "NhanvienTutt");

            migrationBuilder.RenameColumn(
                name: "SoTUTT",
                table: "TblTutts",
                newName: "SoTutt");

            migrationBuilder.RenameColumn(
                name: "Noi_dung",
                table: "TblTutts",
                newName: "NoiDung");

            migrationBuilder.RenameColumn(
                name: "Ghi_chu",
                table: "TblTutts",
                newName: "GhiChu");

            migrationBuilder.AlterColumn<string>(
                name: "TenPhi",
                table: "TblTuttsPhi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoTutt",
                table: "TblTuttsPhi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoHoaDon",
                table: "TblTuttsPhi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NghiChu",
                table: "TblTuttsPhi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoTuttNavigationSoTutt",
                table: "TblTuttsPhi",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NhanvienTutt",
                table: "TblTutts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoTutt",
                table: "TblTutts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "TblTutts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "TblTutts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblTutts",
                table: "TblTutts",
                column: "SoTutt");

            migrationBuilder.CreateIndex(
                name: "IX_TblTuttsPhi_SoTuttNavigationSoTutt",
                table: "TblTuttsPhi",
                column: "SoTuttNavigationSoTutt");

            migrationBuilder.AddForeignKey(
                name: "FK_TblTuttsPhi_TblTutts_SoTuttNavigationSoTutt",
                table: "TblTuttsPhi",
                column: "SoTuttNavigationSoTutt",
                principalTable: "TblTutts",
                principalColumn: "SoTutt");
        }
    }
}
