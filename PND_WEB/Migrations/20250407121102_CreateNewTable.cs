using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentActions_Agents_CodeNavigationCode",
                table: "AgentActions");

            migrationBuilder.DropForeignKey(
                name: "FK_CarrierActions_Carriers_CodeNavigationCode",
                table: "CarrierActions");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJobs_Agents_AgentNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJobs_Carriers_CarrierNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carriers",
                table: "Carriers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrierActions",
                table: "CarrierActions");

            migrationBuilder.DropIndex(
                name: "IX_CarrierActions_CodeNavigationCode",
                table: "CarrierActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentActions",
                table: "AgentActions");

            migrationBuilder.DropIndex(
                name: "IX_AgentActions_CodeNavigationCode",
                table: "AgentActions");

            migrationBuilder.DropColumn(
                name: "CodeNavigationCode",
                table: "CarrierActions");

            migrationBuilder.DropColumn(
                name: "CodeNavigationCode",
                table: "AgentActions");

            migrationBuilder.RenameTable(
                name: "Carriers",
                newName: "CARRIER");

            migrationBuilder.RenameTable(
                name: "CarrierActions",
                newName: "CARRIER_ACTION");

            migrationBuilder.RenameTable(
                name: "Agents",
                newName: "AGENT");

            migrationBuilder.RenameTable(
                name: "AgentActions",
                newName: "AGENT_ACTION");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "CARRIER",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "CarrierNamekd",
                table: "CARRIER",
                newName: "Carrier_namekd");

            migrationBuilder.RenameColumn(
                name: "CarrierName",
                table: "CARRIER",
                newName: "Carrier_name");

            migrationBuilder.RenameColumn(
                name: "CarierAdd",
                table: "CARRIER",
                newName: "Carier_add");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "CARRIER_ACTION",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CARRIER_ACTION",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "CARRIER_ACTION",
                newName: "Phone_number");

            migrationBuilder.RenameColumn(
                name: "PersonInCharge",
                table: "CARRIER_ACTION",
                newName: "Person_in_charge");

            migrationBuilder.RenameColumn(
                name: "LccFee",
                table: "CARRIER_ACTION",
                newName: "LCC_Fee");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "AGENT",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "AgentNamekd",
                table: "AGENT",
                newName: "Agent_namekd");

            migrationBuilder.RenameColumn(
                name: "AgentName",
                table: "AGENT",
                newName: "Agent_name");

            migrationBuilder.RenameColumn(
                name: "AgentAdd",
                table: "AGENT",
                newName: "Agent_add");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "AGENT_ACTION",
                newName: "CODE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AGENT_ACTION",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "AGENT_ACTION",
                newName: "Phone_number");

            migrationBuilder.RenameColumn(
                name: "PersonInCharge",
                table: "AGENT_ACTION",
                newName: "Person_in_charge");

            migrationBuilder.AlterColumn<string>(
                name: "CarrierNavigationCode",
                table: "TblJobs",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentNavigationCode",
                table: "TblJobs",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "CARRIER",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Carrier_namekd",
                table: "CARRIER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Carrier_name",
                table: "CARRIER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Carier_add",
                table: "CARRIER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "CARRIER_ACTION",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "CARRIER_ACTION",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "CARRIER_ACTION",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone_number",
                table: "CARRIER_ACTION",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Person_in_charge",
                table: "CARRIER_ACTION",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LCC_Fee",
                table: "CARRIER_ACTION",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "AGENT",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Agent_namekd",
                table: "AGENT",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Agent_name",
                table: "AGENT",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Agent_add",
                table: "AGENT",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AGENT_ACTION",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODE",
                table: "AGENT_ACTION",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone_number",
                table: "AGENT_ACTION",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Person_in_charge",
                table: "AGENT_ACTION",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CARRIER",
                table: "CARRIER",
                column: "CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CARRIER_ACTION",
                table: "CARRIER_ACTION",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AGENT",
                table: "AGENT",
                column: "CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AGENT_ACTION",
                table: "AGENT_ACTION",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_CARRIER_ACTION_CODE",
                table: "CARRIER_ACTION",
                column: "CODE");

            migrationBuilder.CreateIndex(
                name: "IX_AGENT_ACTION_CODE",
                table: "AGENT_ACTION",
                column: "CODE");

            migrationBuilder.AddForeignKey(
                name: "FK_AGENT_ACTION_AGENT_CODE",
                table: "AGENT_ACTION",
                column: "CODE",
                principalTable: "AGENT",
                principalColumn: "CODE");

            migrationBuilder.AddForeignKey(
                name: "FK_CARRIER_ACTION_CARRIER_CODE",
                table: "CARRIER_ACTION",
                column: "CODE",
                principalTable: "CARRIER",
                principalColumn: "CODE");

            migrationBuilder.AddForeignKey(
                name: "FK_TblJobs_AGENT_AgentNavigationCode",
                table: "TblJobs",
                column: "AgentNavigationCode",
                principalTable: "AGENT",
                principalColumn: "CODE");

            migrationBuilder.AddForeignKey(
                name: "FK_TblJobs_CARRIER_CarrierNavigationCode",
                table: "TblJobs",
                column: "CarrierNavigationCode",
                principalTable: "CARRIER",
                principalColumn: "CODE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGENT_ACTION_AGENT_CODE",
                table: "AGENT_ACTION");

            migrationBuilder.DropForeignKey(
                name: "FK_CARRIER_ACTION_CARRIER_CODE",
                table: "CARRIER_ACTION");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJobs_AGENT_AgentNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJobs_CARRIER_CarrierNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CARRIER_ACTION",
                table: "CARRIER_ACTION");

            migrationBuilder.DropIndex(
                name: "IX_CARRIER_ACTION_CODE",
                table: "CARRIER_ACTION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CARRIER",
                table: "CARRIER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AGENT_ACTION",
                table: "AGENT_ACTION");

            migrationBuilder.DropIndex(
                name: "IX_AGENT_ACTION_CODE",
                table: "AGENT_ACTION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AGENT",
                table: "AGENT");

            migrationBuilder.RenameTable(
                name: "CARRIER_ACTION",
                newName: "CarrierActions");

            migrationBuilder.RenameTable(
                name: "CARRIER",
                newName: "Carriers");

            migrationBuilder.RenameTable(
                name: "AGENT_ACTION",
                newName: "AgentActions");

            migrationBuilder.RenameTable(
                name: "AGENT",
                newName: "Agents");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "CarrierActions",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CarrierActions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Phone_number",
                table: "CarrierActions",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Person_in_charge",
                table: "CarrierActions",
                newName: "PersonInCharge");

            migrationBuilder.RenameColumn(
                name: "LCC_Fee",
                table: "CarrierActions",
                newName: "LccFee");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Carriers",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "Carrier_namekd",
                table: "Carriers",
                newName: "CarrierNamekd");

            migrationBuilder.RenameColumn(
                name: "Carrier_name",
                table: "Carriers",
                newName: "CarrierName");

            migrationBuilder.RenameColumn(
                name: "Carier_add",
                table: "Carriers",
                newName: "CarierAdd");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "AgentActions",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "AgentActions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Phone_number",
                table: "AgentActions",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Person_in_charge",
                table: "AgentActions",
                newName: "PersonInCharge");

            migrationBuilder.RenameColumn(
                name: "CODE",
                table: "Agents",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "Agent_namekd",
                table: "Agents",
                newName: "AgentNamekd");

            migrationBuilder.RenameColumn(
                name: "Agent_name",
                table: "Agents",
                newName: "AgentName");

            migrationBuilder.RenameColumn(
                name: "Agent_add",
                table: "Agents",
                newName: "AgentAdd");

            migrationBuilder.AlterColumn<string>(
                name: "CarrierNavigationCode",
                table: "TblJobs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentNavigationCode",
                table: "TblJobs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "CarrierActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "CarrierActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CarrierActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CarrierActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonInCharge",
                table: "CarrierActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LccFee",
                table: "CarrierActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeNavigationCode",
                table: "CarrierActions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Carriers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CarrierNamekd",
                table: "Carriers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarrierName",
                table: "Carriers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarierAdd",
                table: "Carriers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AgentActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AgentActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AgentActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonInCharge",
                table: "AgentActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeNavigationCode",
                table: "AgentActions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Agents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "AgentNamekd",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentName",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentAdd",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrierActions",
                table: "CarrierActions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carriers",
                table: "Carriers",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentActions",
                table: "AgentActions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_CarrierActions_CodeNavigationCode",
                table: "CarrierActions",
                column: "CodeNavigationCode");

            migrationBuilder.CreateIndex(
                name: "IX_AgentActions_CodeNavigationCode",
                table: "AgentActions",
                column: "CodeNavigationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentActions_Agents_CodeNavigationCode",
                table: "AgentActions",
                column: "CodeNavigationCode",
                principalTable: "Agents",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrierActions_Carriers_CodeNavigationCode",
                table: "CarrierActions",
                column: "CodeNavigationCode",
                principalTable: "Carriers",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TblJobs_Agents_AgentNavigationCode",
                table: "TblJobs",
                column: "AgentNavigationCode",
                principalTable: "Agents",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TblJobs_Carriers_CarrierNavigationCode",
                table: "TblJobs",
                column: "CarrierNavigationCode",
                principalTable: "Carriers",
                principalColumn: "Code");
        }
    }
}
