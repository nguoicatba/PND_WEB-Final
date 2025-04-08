using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init482025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblHscodes",
                table: "TblHscodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlTypes",
                table: "BlTypes");

            migrationBuilder.RenameTable(
                name: "TblHscodes",
                newName: "tbl_HSCODE");

            migrationBuilder.RenameTable(
                name: "BlTypes",
                newName: "BL_TYPE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_HSCODE",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ThueVat",
                table: "tbl_HSCODE",
                newName: "Thue_VAT");

            migrationBuilder.RenameColumn(
                name: "ThueNkUd",
                table: "tbl_HSCODE",
                newName: "Thue_NK_UD");

            migrationBuilder.RenameColumn(
                name: "ThueNkTt",
                table: "tbl_HSCODE",
                newName: "Thue_NK_TT");

            migrationBuilder.RenameColumn(
                name: "ThueBvmt",
                table: "tbl_HSCODE",
                newName: "Thue_BVMT");

            migrationBuilder.RenameColumn(
                name: "MoTaKhongDau",
                table: "tbl_HSCODE",
                newName: "Mo_ta_khong_dau");

            migrationBuilder.RenameColumn(
                name: "MoTaHangHoaV",
                table: "tbl_HSCODE",
                newName: "Mo_ta_hang_hoaV");

            migrationBuilder.RenameColumn(
                name: "MoTaHangHoaE",
                table: "tbl_HSCODE",
                newName: "Mo_ta_hang_hoaE");

            migrationBuilder.RenameColumn(
                name: "HsCode",
                table: "tbl_HSCODE",
                newName: "HS_CODE");

            migrationBuilder.RenameColumn(
                name: "GiamVat",
                table: "tbl_HSCODE",
                newName: "Giam_VAT");

            migrationBuilder.RenameColumn(
                name: "GhiChuKhongDau",
                table: "tbl_HSCODE",
                newName: "Ghi_chu_khong_dau");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "tbl_HSCODE",
                newName: "Ghi_chu");

            migrationBuilder.RenameColumn(
                name: "DonViTinh",
                table: "tbl_HSCODE",
                newName: "Don_vi_tinh");

            migrationBuilder.RenameColumn(
                name: "ChinhSachHangHoa",
                table: "tbl_HSCODE",
                newName: "Chinh_sach_hang_hoa");

            migrationBuilder.RenameColumn(
                name: "ChiTietGiamVat",
                table: "tbl_HSCODE",
                newName: "Chi_tiet_giam_VAT");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "BL_TYPE",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "BlName",
                table: "BL_TYPE",
                newName: "BL_name");

            migrationBuilder.AlterColumn<string>(
                name: "Thue_VAT",
                table: "tbl_HSCODE",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Thue_BVMT",
                table: "tbl_HSCODE",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Giam_VAT",
                table: "tbl_HSCODE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Don_vi_tinh",
                table: "tbl_HSCODE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Chinh_sach_hang_hoa",
                table: "tbl_HSCODE",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Chi_tiet_giam_VAT",
                table: "tbl_HSCODE",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "BL_TYPE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "BL_TYPE",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BL_name",
                table: "BL_TYPE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_HSCODE",
                table: "tbl_HSCODE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BL_TYPE",
                table: "BL_TYPE",
                column: "CODE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_HSCODE",
                table: "tbl_HSCODE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BL_TYPE",
                table: "BL_TYPE");

            migrationBuilder.RenameTable(
                name: "tbl_HSCODE",
                newName: "TblHscodes");

            migrationBuilder.RenameTable(
                name: "BL_TYPE",
                newName: "BlTypes");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TblHscodes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Thue_VAT",
                table: "TblHscodes",
                newName: "ThueVat");

            migrationBuilder.RenameColumn(
                name: "Thue_NK_UD",
                table: "TblHscodes",
                newName: "ThueNkUd");

            migrationBuilder.RenameColumn(
                name: "Thue_NK_TT",
                table: "TblHscodes",
                newName: "ThueNkTt");

            migrationBuilder.RenameColumn(
                name: "Thue_BVMT",
                table: "TblHscodes",
                newName: "ThueBvmt");

            migrationBuilder.RenameColumn(
                name: "Mo_ta_khong_dau",
                table: "TblHscodes",
                newName: "MoTaKhongDau");

            migrationBuilder.RenameColumn(
                name: "Mo_ta_hang_hoaV",
                table: "TblHscodes",
                newName: "MoTaHangHoaV");

            migrationBuilder.RenameColumn(
                name: "Mo_ta_hang_hoaE",
                table: "TblHscodes",
                newName: "MoTaHangHoaE");

            migrationBuilder.RenameColumn(
                name: "HS_CODE",
                table: "TblHscodes",
                newName: "HsCode");

            migrationBuilder.RenameColumn(
                name: "Giam_VAT",
                table: "TblHscodes",
                newName: "GiamVat");

            migrationBuilder.RenameColumn(
                name: "Ghi_chu_khong_dau",
                table: "TblHscodes",
                newName: "GhiChuKhongDau");

            migrationBuilder.RenameColumn(
                name: "Ghi_chu",
                table: "TblHscodes",
                newName: "GhiChu");

            migrationBuilder.RenameColumn(
                name: "Don_vi_tinh",
                table: "TblHscodes",
                newName: "DonViTinh");

            migrationBuilder.RenameColumn(
                name: "Chinh_sach_hang_hoa",
                table: "TblHscodes",
                newName: "ChinhSachHangHoa");

            migrationBuilder.RenameColumn(
                name: "Chi_tiet_giam_VAT",
                table: "TblHscodes",
                newName: "ChiTietGiamVat");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "BlTypes",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "BL_name",
                table: "BlTypes",
                newName: "BlName");

            migrationBuilder.AlterColumn<string>(
                name: "ThueVat",
                table: "TblHscodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThueBvmt",
                table: "TblHscodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GiamVat",
                table: "TblHscodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DonViTinh",
                table: "TblHscodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChinhSachHangHoa",
                table: "TblHscodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChiTietGiamVat",
                table: "TblHscodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "BlTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "BlTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "BlName",
                table: "BlTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblHscodes",
                table: "TblHscodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlTypes",
                table: "BlTypes",
                column: "Code");
        }
    }
}
