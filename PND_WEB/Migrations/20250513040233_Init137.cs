using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init137 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_AspNetUsers_User_ID",
                table: "Job_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_tbl_JOB_Job_ID",
                table: "Job_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job_User",
                table: "Job_User");

            migrationBuilder.DropIndex(
                name: "IX_Job_User_User_ID",
                table: "Job_User");

            migrationBuilder.AlterColumn<string>(
                name: "User_ID",
                table: "Job_User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Job_ID",
                table: "Job_User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Job_User",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job_User",
                table: "Job_User",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Job_User",
                table: "Job_User");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Job_User");

            migrationBuilder.AlterColumn<string>(
                name: "User_ID",
                table: "Job_User",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Job_ID",
                table: "Job_User",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job_User",
                table: "Job_User",
                columns: new[] { "Job_ID", "User_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_Job_User_User_ID",
                table: "Job_User",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_AspNetUsers_User_ID",
                table: "Job_User",
                column: "User_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_tbl_JOB_Job_ID",
                table: "Job_User",
                column: "Job_ID",
                principalTable: "tbl_JOB",
                principalColumn: "Job_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
