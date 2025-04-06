using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init47 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Kindofpackages",
                table: "Kindofpackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modes",
                table: "Modes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fees",
                table: "Fees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cports",
                table: "Cports");

            migrationBuilder.RenameTable(
                name: "Kindofpackages",
                newName: "KINDOFPACKAGES");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "UNIT");

            migrationBuilder.RenameTable(
                name: "Modes",
                newName: "MODE");

            migrationBuilder.RenameTable(
                name: "Fees",
                newName: "FEE");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "CURRENCY");

            migrationBuilder.RenameTable(
                name: "Cports",
                newName: "CPORT");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "KINDOFPACKAGES",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "PackagesDescription",
                table: "KINDOFPACKAGES",
                newName: "Packages_description");

            migrationBuilder.RenameColumn(
                name: "PackageName",
                table: "KINDOFPACKAGES",
                newName: "Package_name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "UNIT",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "UnitName",
                table: "UNIT",
                newName: "Unit_name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "MODE",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "FEE",
                newName: "UNIT");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "FEE",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "Fee1",
                table: "FEE",
                newName: "FEE");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "CURRENCY",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "CurrName",
                table: "CURRENCY",
                newName: "Curr_name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "CPORT",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "PortName",
                table: "CPORT",
                newName: "PORT_NAME");

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "KINDOFPACKAGES",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Packages_description",
                table: "KINDOFPACKAGES",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Package_name",
                table: "KINDOFPACKAGES",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "UNIT",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "UNIT",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Unit_name",
                table: "UNIT",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "MODE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "MODE",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UNIT",
                table: "FEE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTE",
                table: "FEE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FEE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FEE",
                table: "FEE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "CURRENCY",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "CURRENCY",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Curr_name",
                table: "CURRENCY",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "CPORT",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KINDOFPACKAGES",
                table: "KINDOFPACKAGES",
                column: "CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UNIT",
                table: "UNIT",
                column: "CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MODE",
                table: "MODE",
                column: "CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FEE",
                table: "FEE",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CURRENCY",
                table: "CURRENCY",
                column: "CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CPORT",
                table: "CPORT",
                column: "CODE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KINDOFPACKAGES",
                table: "KINDOFPACKAGES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UNIT",
                table: "UNIT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MODE",
                table: "MODE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FEE",
                table: "FEE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CURRENCY",
                table: "CURRENCY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CPORT",
                table: "CPORT");

            migrationBuilder.RenameTable(
                name: "KINDOFPACKAGES",
                newName: "Kindofpackages");

            migrationBuilder.RenameTable(
                name: "UNIT",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "MODE",
                newName: "Modes");

            migrationBuilder.RenameTable(
                name: "FEE",
                newName: "Fees");

            migrationBuilder.RenameTable(
                name: "CURRENCY",
                newName: "Currencies");

            migrationBuilder.RenameTable(
                name: "CPORT",
                newName: "Cports");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Kindofpackages",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "Packages_description",
                table: "Kindofpackages",
                newName: "PackagesDescription");

            migrationBuilder.RenameColumn(
                name: "Package_name",
                table: "Kindofpackages",
                newName: "PackageName");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Units",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "Unit_name",
                table: "Units",
                newName: "UnitName");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Modes",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "UNIT",
                table: "Fees",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "Fees",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "FEE",
                table: "Fees",
                newName: "Fee1");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Currencies",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "Curr_name",
                table: "Currencies",
                newName: "CurrName");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Cports",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "PORT_NAME",
                table: "Cports",
                newName: "PortName");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Kindofpackages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "PackagesDescription",
                table: "Kindofpackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PackageName",
                table: "Kindofpackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Units",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "UnitName",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Modes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Modes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Fees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Fee1",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Currencies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CurrName",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Cports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kindofpackages",
                table: "Kindofpackages",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modes",
                table: "Modes",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fees",
                table: "Fees",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cports",
                table: "Cports",
                column: "Code");
        }
    }
}
