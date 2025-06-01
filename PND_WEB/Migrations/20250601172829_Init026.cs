using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INVOICE_CHARGE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invoice_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ser_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ser_Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ser_Quantity = table.Column<float>(type: "real", nullable: true),
                    Ser_Price = table.Column<float>(type: "real", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Exchange_rate = table.Column<float>(type: "real", nullable: true),
                    Ser_VAT = table.Column<float>(type: "real", nullable: true),
                    M_VAT = table.Column<float>(type: "real", nullable: true),
                    Checked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICE_CHARGE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVOICE_CHARGE_INVOICE_Invoice_ID",
                        column: x => x.Invoice_ID,
                        principalTable: "INVOICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INVOICE_CHARGE_Invoice_ID",
                table: "INVOICE_CHARGE",
                column: "Invoice_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INVOICE_CHARGE");
        }
    }
}
