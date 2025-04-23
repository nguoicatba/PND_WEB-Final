using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init224 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCharges_TblInvoices_DebitId",
                table: "TblCharges");

            migrationBuilder.DropForeignKey(
                name: "FK_TblInvoices_tbl_HBL_HblNavigationHbl",
                table: "TblInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TblInvoices_tbl_SUPPLIER_SupplierId",
                table: "TblInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblInvoices",
                table: "TblInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCharges",
                table: "TblCharges");

            migrationBuilder.RenameTable(
                name: "TblInvoices",
                newName: "tbl_INVOICE");

            migrationBuilder.RenameTable(
                name: "TblCharges",
                newName: "tbl_CHARGES");

            migrationBuilder.RenameColumn(
                name: "Hbl",
                table: "tbl_INVOICE",
                newName: "HBL");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "tbl_INVOICE",
                newName: "Supplier_ID");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "tbl_INVOICE",
                newName: "Payment_date");

            migrationBuilder.RenameColumn(
                name: "InvoiceType",
                table: "tbl_INVOICE",
                newName: "Invoice_type");

            migrationBuilder.RenameColumn(
                name: "InvoiceNo",
                table: "tbl_INVOICE",
                newName: "Invoice_No");

            migrationBuilder.RenameColumn(
                name: "InvoiceDate",
                table: "tbl_INVOICE",
                newName: "Invoice_date");

            migrationBuilder.RenameColumn(
                name: "DebitDate",
                table: "tbl_INVOICE",
                newName: "Debit_date");

            migrationBuilder.RenameColumn(
                name: "DebitId",
                table: "tbl_INVOICE",
                newName: "Debit_ID");

            migrationBuilder.RenameColumn(
                name: "HblNavigationHbl",
                table: "tbl_INVOICE",
                newName: "HBL1");

            migrationBuilder.RenameIndex(
                name: "IX_TblInvoices_SupplierId",
                table: "tbl_INVOICE",
                newName: "IX_tbl_INVOICE_Supplier_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TblInvoices_HblNavigationHbl",
                table: "tbl_INVOICE",
                newName: "IX_tbl_INVOICE_HBL1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_CHARGES",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SerVat",
                table: "tbl_CHARGES",
                newName: "Ser_VAT");

            migrationBuilder.RenameColumn(
                name: "SerUnit",
                table: "tbl_CHARGES",
                newName: "Ser_Unit");

            migrationBuilder.RenameColumn(
                name: "SerQuantity",
                table: "tbl_CHARGES",
                newName: "Ser_Quantity");

            migrationBuilder.RenameColumn(
                name: "SerPrice",
                table: "tbl_CHARGES",
                newName: "Ser_Price");

            migrationBuilder.RenameColumn(
                name: "SerName",
                table: "tbl_CHARGES",
                newName: "Ser_Name");

            migrationBuilder.RenameColumn(
                name: "MVat",
                table: "tbl_CHARGES",
                newName: "M_VAT");

            migrationBuilder.RenameColumn(
                name: "ExchangeRate",
                table: "tbl_CHARGES",
                newName: "Exchange_rate");

            migrationBuilder.RenameColumn(
                name: "DebitId",
                table: "tbl_CHARGES",
                newName: "Debit_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TblCharges_DebitId",
                table: "tbl_CHARGES",
                newName: "IX_tbl_CHARGES_Debit_ID");

            migrationBuilder.AlterColumn<string>(
                name: "HBL",
                table: "tbl_INVOICE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Invoice_type",
                table: "tbl_INVOICE",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Invoice_No",
                table: "tbl_INVOICE",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Debit_ID",
                table: "tbl_INVOICE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "tbl_CHARGES",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ser_Unit",
                table: "tbl_CHARGES",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ser_Name",
                table: "tbl_CHARGES",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Debit_ID",
                table: "tbl_CHARGES",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_INVOICE",
                table: "tbl_INVOICE",
                column: "Debit_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CHARGES",
                table: "tbl_CHARGES",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CHARGES_tbl_INVOICE_Debit_ID",
                table: "tbl_CHARGES",
                column: "Debit_ID",
                principalTable: "tbl_INVOICE",
                principalColumn: "Debit_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_INVOICE_tbl_HBL_HBL1",
                table: "tbl_INVOICE",
                column: "HBL1",
                principalTable: "tbl_HBL",
                principalColumn: "HBL");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_INVOICE_tbl_SUPPLIER_Supplier_ID",
                table: "tbl_INVOICE",
                column: "Supplier_ID",
                principalTable: "tbl_SUPPLIER",
                principalColumn: "Supplier_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CHARGES_tbl_INVOICE_Debit_ID",
                table: "tbl_CHARGES");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_INVOICE_tbl_HBL_HBL1",
                table: "tbl_INVOICE");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_INVOICE_tbl_SUPPLIER_Supplier_ID",
                table: "tbl_INVOICE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_INVOICE",
                table: "tbl_INVOICE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CHARGES",
                table: "tbl_CHARGES");

            migrationBuilder.RenameTable(
                name: "tbl_INVOICE",
                newName: "TblInvoices");

            migrationBuilder.RenameTable(
                name: "tbl_CHARGES",
                newName: "TblCharges");

            migrationBuilder.RenameColumn(
                name: "HBL",
                table: "TblInvoices",
                newName: "Hbl");

            migrationBuilder.RenameColumn(
                name: "Supplier_ID",
                table: "TblInvoices",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "Payment_date",
                table: "TblInvoices",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "Invoice_type",
                table: "TblInvoices",
                newName: "InvoiceType");

            migrationBuilder.RenameColumn(
                name: "Invoice_date",
                table: "TblInvoices",
                newName: "InvoiceDate");

            migrationBuilder.RenameColumn(
                name: "Invoice_No",
                table: "TblInvoices",
                newName: "InvoiceNo");

            migrationBuilder.RenameColumn(
                name: "Debit_date",
                table: "TblInvoices",
                newName: "DebitDate");

            migrationBuilder.RenameColumn(
                name: "Debit_ID",
                table: "TblInvoices",
                newName: "DebitId");

            migrationBuilder.RenameColumn(
                name: "HBL1",
                table: "TblInvoices",
                newName: "HblNavigationHbl");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_INVOICE_Supplier_ID",
                table: "TblInvoices",
                newName: "IX_TblInvoices_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_INVOICE_HBL1",
                table: "TblInvoices",
                newName: "IX_TblInvoices_HblNavigationHbl");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TblCharges",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Ser_VAT",
                table: "TblCharges",
                newName: "SerVat");

            migrationBuilder.RenameColumn(
                name: "Ser_Unit",
                table: "TblCharges",
                newName: "SerUnit");

            migrationBuilder.RenameColumn(
                name: "Ser_Quantity",
                table: "TblCharges",
                newName: "SerQuantity");

            migrationBuilder.RenameColumn(
                name: "Ser_Price",
                table: "TblCharges",
                newName: "SerPrice");

            migrationBuilder.RenameColumn(
                name: "Ser_Name",
                table: "TblCharges",
                newName: "SerName");

            migrationBuilder.RenameColumn(
                name: "M_VAT",
                table: "TblCharges",
                newName: "MVat");

            migrationBuilder.RenameColumn(
                name: "Exchange_rate",
                table: "TblCharges",
                newName: "ExchangeRate");

            migrationBuilder.RenameColumn(
                name: "Debit_ID",
                table: "TblCharges",
                newName: "DebitId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_CHARGES_Debit_ID",
                table: "TblCharges",
                newName: "IX_TblCharges_DebitId");

            migrationBuilder.AlterColumn<string>(
                name: "Hbl",
                table: "TblInvoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceType",
                table: "TblInvoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNo",
                table: "TblInvoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DebitId",
                table: "TblInvoices",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "TblCharges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SerUnit",
                table: "TblCharges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SerName",
                table: "TblCharges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DebitId",
                table: "TblCharges",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblInvoices",
                table: "TblInvoices",
                column: "DebitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCharges",
                table: "TblCharges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCharges_TblInvoices_DebitId",
                table: "TblCharges",
                column: "DebitId",
                principalTable: "TblInvoices",
                principalColumn: "DebitId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblInvoices_tbl_HBL_HblNavigationHbl",
                table: "TblInvoices",
                column: "HblNavigationHbl",
                principalTable: "tbl_HBL",
                principalColumn: "HBL");

            migrationBuilder.AddForeignKey(
                name: "FK_TblInvoices_tbl_SUPPLIER_SupplierId",
                table: "TblInvoices",
                column: "SupplierId",
                principalTable: "tbl_SUPPLIER",
                principalColumn: "Supplier_ID");
        }
    }
}
