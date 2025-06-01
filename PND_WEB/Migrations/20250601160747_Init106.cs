using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INVOICE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Partner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Invoice_No = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Exchange_rate = table.Column<float>(type: "real", nullable: true),
                    Debit_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Payment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Invoice_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HBL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICE", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INVOICE");
        }
    }
}
