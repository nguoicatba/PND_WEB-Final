using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sourses",
                table: "Sourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceTypes",
                table: "InvoiceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoodsTypes",
                table: "GoodsTypes");

            migrationBuilder.RenameTable(
                name: "Sourses",
                newName: "SOURSE");

            migrationBuilder.RenameTable(
                name: "InvoiceTypes",
                newName: "INVOICE_TYPE");

            migrationBuilder.RenameTable(
                name: "GoodsTypes",
                newName: "GOODS_TYPE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SOURSE",
                table: "SOURSE",
                column: "CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_INVOICE_TYPE",
                table: "INVOICE_TYPE",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GOODS_TYPE",
                table: "GOODS_TYPE",
                column: "CODE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SOURSE",
                table: "SOURSE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_INVOICE_TYPE",
                table: "INVOICE_TYPE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GOODS_TYPE",
                table: "GOODS_TYPE");

            migrationBuilder.RenameTable(
                name: "SOURSE",
                newName: "Sourses");

            migrationBuilder.RenameTable(
                name: "INVOICE_TYPE",
                newName: "InvoiceTypes");

            migrationBuilder.RenameTable(
                name: "GOODS_TYPE",
                newName: "GoodsTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sourses",
                table: "Sourses",
                column: "CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceTypes",
                table: "InvoiceTypes",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoodsTypes",
                table: "GoodsTypes",
                column: "CODE");
        }
    }
}
