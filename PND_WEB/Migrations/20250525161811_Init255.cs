using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init255 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobOwner",
                table: "tbl_JOB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "JobStatus",
                table: "tbl_JOB",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobOwner",
                table: "tbl_JOB");

            migrationBuilder.DropColumn(
                name: "JobStatus",
                table: "tbl_JOB");
        }
    }
}
