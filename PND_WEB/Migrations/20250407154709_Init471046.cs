using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class Init471046 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCneeAdds_TblCnees_CneeNavigationCnee",
                table: "TblCneeAdds");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConths_TblHbls_HblNavigationHbl",
                table: "TblConths");

            migrationBuilder.DropForeignKey(
                name: "FK_TblHbls_TblCnees_CneeNavigationCnee",
                table: "TblHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_TblHbls_TblJobs_RequestId",
                table: "TblHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_TblHbls_TblShippers_ShipperNavigationShipper",
                table: "TblHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_TblHbls_tbl_CUSTOMER_CustomerId",
                table: "TblHbls");

            migrationBuilder.DropForeignKey(
                name: "FK_TblInvoices_TblHbls_HblNavigationHbl",
                table: "TblInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TblInvoices_TblSuppliers_SupplierId",
                table: "TblInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJobs_AGENT_AgentNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_TblJobs_CARRIER_CarrierNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSupplierActions_TblSuppliers_SupplierId",
                table: "TblSupplierActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSuppliers",
                table: "TblSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSupplierActions",
                table: "TblSupplierActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblShippers",
                table: "TblShippers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblJobs",
                table: "TblJobs");

            migrationBuilder.DropIndex(
                name: "IX_TblJobs_AgentNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropIndex(
                name: "IX_TblJobs_CarrierNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblHbls",
                table: "TblHbls");

            migrationBuilder.DropIndex(
                name: "IX_TblHbls_CneeNavigationCnee",
                table: "TblHbls");

            migrationBuilder.DropIndex(
                name: "IX_TblHbls_ShipperNavigationShipper",
                table: "TblHbls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCnees",
                table: "TblCnees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCneeAdds",
                table: "TblCneeAdds");

            migrationBuilder.DropIndex(
                name: "IX_TblCneeAdds_CneeNavigationCnee",
                table: "TblCneeAdds");

            migrationBuilder.DropColumn(
                name: "AgentNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropColumn(
                name: "CarrierNavigationCode",
                table: "TblJobs");

            migrationBuilder.DropColumn(
                name: "CneeNavigationCnee",
                table: "TblHbls");

            migrationBuilder.DropColumn(
                name: "ShipperNavigationShipper",
                table: "TblHbls");

            migrationBuilder.DropColumn(
                name: "CneeNavigationCnee",
                table: "TblCneeAdds");

            migrationBuilder.RenameTable(
                name: "TblSuppliers",
                newName: "tbl_SUPPLIER");

            migrationBuilder.RenameTable(
                name: "TblSupplierActions",
                newName: "tbl_SUPPLIER_ACTION");

            migrationBuilder.RenameTable(
                name: "TblShippers",
                newName: "tbl_SHIPPER");

            migrationBuilder.RenameTable(
                name: "TblJobs",
                newName: "tbl_JOB");

            migrationBuilder.RenameTable(
                name: "TblHbls",
                newName: "tbl_HBL");

            migrationBuilder.RenameTable(
                name: "TblCnees",
                newName: "tbl_CNEE");

            migrationBuilder.RenameTable(
                name: "TblCneeAdds",
                newName: "tbl_CNEE_ADD");

            migrationBuilder.RenameColumn(
                name: "DutyPerson",
                table: "tbl_CUSTOMER",
                newName: "Duty_Person");

            migrationBuilder.RenameColumn(
                name: "CompanyNamekd",
                table: "tbl_CUSTOMER",
                newName: "Company_Namekd");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "tbl_CUSTOMER",
                newName: "Company_Name");

            migrationBuilder.RenameColumn(
                name: "ComAddresskd",
                table: "tbl_CUSTOMER",
                newName: "Com_Addresskd");

            migrationBuilder.RenameColumn(
                name: "ComAddress",
                table: "tbl_CUSTOMER",
                newName: "Com_Address");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "tbl_CUSTOMER",
                newName: "Customer_ID");

            migrationBuilder.RenameColumn(
                name: "NameSup",
                table: "tbl_SUPPLIER",
                newName: "Name_sup");

            migrationBuilder.RenameColumn(
                name: "LccFee",
                table: "tbl_SUPPLIER",
                newName: "LCC_Fee");

            migrationBuilder.RenameColumn(
                name: "AddressSup",
                table: "tbl_SUPPLIER",
                newName: "Address_sup");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "tbl_SUPPLIER",
                newName: "Supplier_ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_SUPPLIER_ACTION",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "tbl_SUPPLIER_ACTION",
                newName: "Supplier_ID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "tbl_SUPPLIER_ACTION",
                newName: "Phone_number");

            migrationBuilder.RenameColumn(
                name: "PersonInCharge",
                table: "tbl_SUPPLIER_ACTION",
                newName: "Person_in_charge");

            migrationBuilder.RenameIndex(
                name: "IX_TblSupplierActions_SupplierId",
                table: "tbl_SUPPLIER_ACTION",
                newName: "IX_tbl_SUPPLIER_ACTION_Supplier_ID");

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "tbl_SHIPPER",
                newName: "TaxID");

            migrationBuilder.RenameColumn(
                name: "Scity",
                table: "tbl_SHIPPER",
                newName: "SCity");

            migrationBuilder.RenameColumn(
                name: "Saddress",
                table: "tbl_SHIPPER",
                newName: "SAddress");

            migrationBuilder.RenameColumn(
                name: "SpersonInCharge",
                table: "tbl_SHIPPER",
                newName: "SPerson_in_charge");

            migrationBuilder.RenameColumn(
                name: "Pol",
                table: "tbl_JOB",
                newName: "POL");

            migrationBuilder.RenameColumn(
                name: "Podis",
                table: "tbl_JOB",
                newName: "PODis");

            migrationBuilder.RenameColumn(
                name: "Podel",
                table: "tbl_JOB",
                newName: "PODel");

            migrationBuilder.RenameColumn(
                name: "Pod",
                table: "tbl_JOB",
                newName: "POD");

            migrationBuilder.RenameColumn(
                name: "Mbl",
                table: "tbl_JOB",
                newName: "MBL");

            migrationBuilder.RenameColumn(
                name: "Etd",
                table: "tbl_JOB",
                newName: "ETD");

            migrationBuilder.RenameColumn(
                name: "Eta",
                table: "tbl_JOB",
                newName: "ETA");

            migrationBuilder.RenameColumn(
                name: "VoyageName",
                table: "tbl_JOB",
                newName: "Voyage_name");

            migrationBuilder.RenameColumn(
                name: "VesselName",
                table: "tbl_JOB",
                newName: "Vessel_name");

            migrationBuilder.RenameColumn(
                name: "UseTime",
                table: "tbl_JOB",
                newName: "Use_time");

            migrationBuilder.RenameColumn(
                name: "PreCariageBy",
                table: "tbl_JOB",
                newName: "Pre_Cariage_by");

            migrationBuilder.RenameColumn(
                name: "OnBoardDateM",
                table: "tbl_JOB",
                newName: "OnBoard_dateM");

            migrationBuilder.RenameColumn(
                name: "JobDate",
                table: "tbl_JOB",
                newName: "Job_date");

            migrationBuilder.RenameColumn(
                name: "IssueDateM",
                table: "tbl_JOB",
                newName: "Issue_dateM");

            migrationBuilder.RenameColumn(
                name: "GoodsType",
                table: "tbl_JOB",
                newName: "Goods_type");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "tbl_JOB",
                newName: "Job_ID");

            migrationBuilder.RenameColumn(
                name: "Pic",
                table: "tbl_HBL",
                newName: "PIC");

            migrationBuilder.RenameColumn(
                name: "Cnee",
                table: "tbl_HBL",
                newName: "CNEE");

            migrationBuilder.RenameColumn(
                name: "Hbl",
                table: "tbl_HBL",
                newName: "HBL");

            migrationBuilder.RenameColumn(
                name: "SiNo",
                table: "tbl_HBL",
                newName: "SI_No");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "tbl_HBL",
                newName: "Request_ID");

            migrationBuilder.RenameColumn(
                name: "PicPhone",
                table: "tbl_HBL",
                newName: "PIC_phone");

            migrationBuilder.RenameColumn(
                name: "OnBoardDateH",
                table: "tbl_HBL",
                newName: "OnBoard_dateH");

            migrationBuilder.RenameColumn(
                name: "NotifyParty",
                table: "tbl_HBL",
                newName: "Notify_party");

            migrationBuilder.RenameColumn(
                name: "NomFree",
                table: "tbl_HBL",
                newName: "Nom_Free");

            migrationBuilder.RenameColumn(
                name: "MarkNos",
                table: "tbl_HBL",
                newName: "Mark_Nos");

            migrationBuilder.RenameColumn(
                name: "IssuePlaceH",
                table: "tbl_HBL",
                newName: "Issue_placeH");

            migrationBuilder.RenameColumn(
                name: "IssueDateH",
                table: "tbl_HBL",
                newName: "Issue_dateH");

            migrationBuilder.RenameColumn(
                name: "InvoiceNo",
                table: "tbl_HBL",
                newName: "Invoice_No");

            migrationBuilder.RenameColumn(
                name: "GrossWeight",
                table: "tbl_HBL",
                newName: "Gross_weight");

            migrationBuilder.RenameColumn(
                name: "GoodsDesciption",
                table: "tbl_HBL",
                newName: "Goods_desciption");

            migrationBuilder.RenameColumn(
                name: "FreightPayable",
                table: "tbl_HBL",
                newName: "Freight_Payable");

            migrationBuilder.RenameColumn(
                name: "FreightCharge",
                table: "tbl_HBL",
                newName: "Freight_charge");

            migrationBuilder.RenameColumn(
                name: "DoDate",
                table: "tbl_HBL",
                newName: "DO_date");

            migrationBuilder.RenameColumn(
                name: "CustomsDeclarationNo",
                table: "tbl_HBL",
                newName: "Customs_declaration_No");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "tbl_HBL",
                newName: "Customer_ID");

            migrationBuilder.RenameColumn(
                name: "ContSealNo",
                table: "tbl_HBL",
                newName: "Cont_Seal_No");

            migrationBuilder.RenameColumn(
                name: "BlType",
                table: "tbl_HBL",
                newName: "BL_type");

            migrationBuilder.RenameIndex(
                name: "IX_TblHbls_RequestId",
                table: "tbl_HBL",
                newName: "IX_tbl_HBL_Request_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TblHbls_CustomerId",
                table: "tbl_HBL",
                newName: "IX_tbl_HBL_Customer_ID");

            migrationBuilder.RenameColumn(
                name: "Vcnee",
                table: "tbl_CNEE",
                newName: "VCNEE");

            migrationBuilder.RenameColumn(
                name: "Vaddress",
                table: "tbl_CNEE",
                newName: "VAddress");

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "tbl_CNEE",
                newName: "TaxID");

            migrationBuilder.RenameColumn(
                name: "Haddress",
                table: "tbl_CNEE",
                newName: "HAddress");

            migrationBuilder.RenameColumn(
                name: "Ccity",
                table: "tbl_CNEE",
                newName: "CCity");

            migrationBuilder.RenameColumn(
                name: "Caddress",
                table: "tbl_CNEE",
                newName: "CAddress");

            migrationBuilder.RenameColumn(
                name: "Cnee",
                table: "tbl_CNEE",
                newName: "CNEE");

            migrationBuilder.RenameColumn(
                name: "CpersonInCharge",
                table: "tbl_CNEE",
                newName: "CPerson_in_charge");

            migrationBuilder.RenameColumn(
                name: "Cnee",
                table: "tbl_CNEE_ADD",
                newName: "CNEE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_CNEE_ADD",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierId",
                table: "TblInvoices",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HblNavigationHbl",
                table: "TblInvoices",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HblNavigationHbl",
                table: "TblConths",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Typer",
                table: "tbl_SUPPLIER",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "tbl_SUPPLIER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_sup",
                table: "tbl_SUPPLIER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LCC_Fee",
                table: "tbl_SUPPLIER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_sup",
                table: "tbl_SUPPLIER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Supplier_ID",
                table: "tbl_SUPPLIER",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tbl_SUPPLIER_ACTION",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Supplier_ID",
                table: "tbl_SUPPLIER_ACTION",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone_number",
                table: "tbl_SUPPLIER_ACTION",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Person_in_charge",
                table: "tbl_SUPPLIER_ACTION",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxID",
                table: "tbl_SHIPPER",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SCity",
                table: "tbl_SHIPPER",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SAddress",
                table: "tbl_SHIPPER",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Shipper",
                table: "tbl_SHIPPER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SPerson_in_charge",
                table: "tbl_SHIPPER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ycompany",
                table: "tbl_JOB",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POL",
                table: "tbl_JOB",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PODis",
                table: "tbl_JOB",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PODel",
                table: "tbl_JOB",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "POD",
                table: "tbl_JOB",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceofReceipt",
                table: "tbl_JOB",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceofDelivery",
                table: "tbl_JOB",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mode",
                table: "tbl_JOB",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MBL",
                table: "tbl_JOB",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "tbl_JOB",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Carrier",
                table: "tbl_JOB",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Agent",
                table: "tbl_JOB",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Voyage_name",
                table: "tbl_JOB",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Vessel_name",
                table: "tbl_JOB",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pre_Cariage_by",
                table: "tbl_JOB",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Goods_type",
                table: "tbl_JOB",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Job_ID",
                table: "tbl_JOB",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "tbl_HBL",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Shipper",
                table: "tbl_HBL",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "tbl_HBL",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PIC",
                table: "tbl_HBL",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumberofOrigins",
                table: "tbl_HBL",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNEE",
                table: "tbl_HBL",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HBL",
                table: "tbl_HBL",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SI_No",
                table: "tbl_HBL",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Request_ID",
                table: "tbl_HBL",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PIC_phone",
                table: "tbl_HBL",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notify_party",
                table: "tbl_HBL",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom_Free",
                table: "tbl_HBL",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Mark_Nos",
                table: "tbl_HBL",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Issue_placeH",
                table: "tbl_HBL",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Invoice_No",
                table: "tbl_HBL",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Goods_desciption",
                table: "tbl_HBL",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Freight_Payable",
                table: "tbl_HBL",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Customs_declaration_No",
                table: "tbl_HBL",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cont_Seal_No",
                table: "tbl_HBL",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BL_type",
                table: "tbl_HBL",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VCNEE",
                table: "tbl_CNEE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VAddress",
                table: "tbl_CNEE",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxID",
                table: "tbl_CNEE",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HAddress",
                table: "tbl_CNEE",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CCity",
                table: "tbl_CNEE",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CAddress",
                table: "tbl_CNEE",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNEE",
                table: "tbl_CNEE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CPerson_in_charge",
                table: "tbl_CNEE",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "tbl_CNEE_ADD",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonInCharge",
                table: "tbl_CNEE_ADD",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNEE",
                table: "tbl_CNEE_ADD",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adds",
                table: "tbl_CNEE_ADD",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_SUPPLIER",
                table: "tbl_SUPPLIER",
                column: "Supplier_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_SUPPLIER_ACTION",
                table: "tbl_SUPPLIER_ACTION",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_SHIPPER",
                table: "tbl_SHIPPER",
                column: "Shipper");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_JOB",
                table: "tbl_JOB",
                column: "Job_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_HBL",
                table: "tbl_HBL",
                column: "HBL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CNEE",
                table: "tbl_CNEE",
                column: "CNEE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_CNEE_ADD",
                table: "tbl_CNEE_ADD",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_JOB_Agent",
                table: "tbl_JOB",
                column: "Agent");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_JOB_Carrier",
                table: "tbl_JOB",
                column: "Carrier");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HBL_CNEE",
                table: "tbl_HBL",
                column: "CNEE");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HBL_Shipper",
                table: "tbl_HBL",
                column: "Shipper");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CNEE_ADD_CNEE",
                table: "tbl_CNEE_ADD",
                column: "CNEE");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_CNEE_ADD_tbl_CNEE_CNEE",
                table: "tbl_CNEE_ADD",
                column: "CNEE",
                principalTable: "tbl_CNEE",
                principalColumn: "CNEE");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_HBL_tbl_CNEE_CNEE",
                table: "tbl_HBL",
                column: "CNEE",
                principalTable: "tbl_CNEE",
                principalColumn: "CNEE");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_HBL_tbl_CUSTOMER_Customer_ID",
                table: "tbl_HBL",
                column: "Customer_ID",
                principalTable: "tbl_CUSTOMER",
                principalColumn: "Customer_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_HBL_tbl_JOB_Request_ID",
                table: "tbl_HBL",
                column: "Request_ID",
                principalTable: "tbl_JOB",
                principalColumn: "Job_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_HBL_tbl_SHIPPER_Shipper",
                table: "tbl_HBL",
                column: "Shipper",
                principalTable: "tbl_SHIPPER",
                principalColumn: "Shipper");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_JOB_AGENT_Agent",
                table: "tbl_JOB",
                column: "Agent",
                principalTable: "AGENT",
                principalColumn: "CODE");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_JOB_CARRIER_Carrier",
                table: "tbl_JOB",
                column: "Carrier",
                principalTable: "CARRIER",
                principalColumn: "CODE");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_SUPPLIER_ACTION_tbl_SUPPLIER_Supplier_ID",
                table: "tbl_SUPPLIER_ACTION",
                column: "Supplier_ID",
                principalTable: "tbl_SUPPLIER",
                principalColumn: "Supplier_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblConths_tbl_HBL_HblNavigationHbl",
                table: "TblConths",
                column: "HblNavigationHbl",
                principalTable: "tbl_HBL",
                principalColumn: "HBL");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_CNEE_ADD_tbl_CNEE_CNEE",
                table: "tbl_CNEE_ADD");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_HBL_tbl_CNEE_CNEE",
                table: "tbl_HBL");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_HBL_tbl_CUSTOMER_Customer_ID",
                table: "tbl_HBL");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_HBL_tbl_JOB_Request_ID",
                table: "tbl_HBL");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_HBL_tbl_SHIPPER_Shipper",
                table: "tbl_HBL");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_JOB_AGENT_Agent",
                table: "tbl_JOB");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_JOB_CARRIER_Carrier",
                table: "tbl_JOB");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_SUPPLIER_ACTION_tbl_SUPPLIER_Supplier_ID",
                table: "tbl_SUPPLIER_ACTION");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConths_tbl_HBL_HblNavigationHbl",
                table: "TblConths");

            migrationBuilder.DropForeignKey(
                name: "FK_TblInvoices_tbl_HBL_HblNavigationHbl",
                table: "TblInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TblInvoices_tbl_SUPPLIER_SupplierId",
                table: "TblInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_SUPPLIER_ACTION",
                table: "tbl_SUPPLIER_ACTION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_SUPPLIER",
                table: "tbl_SUPPLIER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_SHIPPER",
                table: "tbl_SHIPPER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_JOB",
                table: "tbl_JOB");

            migrationBuilder.DropIndex(
                name: "IX_tbl_JOB_Agent",
                table: "tbl_JOB");

            migrationBuilder.DropIndex(
                name: "IX_tbl_JOB_Carrier",
                table: "tbl_JOB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_HBL",
                table: "tbl_HBL");

            migrationBuilder.DropIndex(
                name: "IX_tbl_HBL_CNEE",
                table: "tbl_HBL");

            migrationBuilder.DropIndex(
                name: "IX_tbl_HBL_Shipper",
                table: "tbl_HBL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CNEE_ADD",
                table: "tbl_CNEE_ADD");

            migrationBuilder.DropIndex(
                name: "IX_tbl_CNEE_ADD_CNEE",
                table: "tbl_CNEE_ADD");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_CNEE",
                table: "tbl_CNEE");

            migrationBuilder.RenameTable(
                name: "tbl_SUPPLIER_ACTION",
                newName: "TblSupplierActions");

            migrationBuilder.RenameTable(
                name: "tbl_SUPPLIER",
                newName: "TblSuppliers");

            migrationBuilder.RenameTable(
                name: "tbl_SHIPPER",
                newName: "TblShippers");

            migrationBuilder.RenameTable(
                name: "tbl_JOB",
                newName: "TblJobs");

            migrationBuilder.RenameTable(
                name: "tbl_HBL",
                newName: "TblHbls");

            migrationBuilder.RenameTable(
                name: "tbl_CNEE_ADD",
                newName: "TblCneeAdds");

            migrationBuilder.RenameTable(
                name: "tbl_CNEE",
                newName: "TblCnees");

            migrationBuilder.RenameColumn(
                name: "Duty_Person",
                table: "tbl_CUSTOMER",
                newName: "DutyPerson");

            migrationBuilder.RenameColumn(
                name: "Company_Namekd",
                table: "tbl_CUSTOMER",
                newName: "CompanyNamekd");

            migrationBuilder.RenameColumn(
                name: "Company_Name",
                table: "tbl_CUSTOMER",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "Com_Addresskd",
                table: "tbl_CUSTOMER",
                newName: "ComAddresskd");

            migrationBuilder.RenameColumn(
                name: "Com_Address",
                table: "tbl_CUSTOMER",
                newName: "ComAddress");

            migrationBuilder.RenameColumn(
                name: "Customer_ID",
                table: "tbl_CUSTOMER",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TblSupplierActions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Supplier_ID",
                table: "TblSupplierActions",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "Phone_number",
                table: "TblSupplierActions",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Person_in_charge",
                table: "TblSupplierActions",
                newName: "PersonInCharge");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_SUPPLIER_ACTION_Supplier_ID",
                table: "TblSupplierActions",
                newName: "IX_TblSupplierActions_SupplierId");

            migrationBuilder.RenameColumn(
                name: "Name_sup",
                table: "TblSuppliers",
                newName: "NameSup");

            migrationBuilder.RenameColumn(
                name: "LCC_Fee",
                table: "TblSuppliers",
                newName: "LccFee");

            migrationBuilder.RenameColumn(
                name: "Address_sup",
                table: "TblSuppliers",
                newName: "AddressSup");

            migrationBuilder.RenameColumn(
                name: "Supplier_ID",
                table: "TblSuppliers",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "TaxID",
                table: "TblShippers",
                newName: "TaxId");

            migrationBuilder.RenameColumn(
                name: "SCity",
                table: "TblShippers",
                newName: "Scity");

            migrationBuilder.RenameColumn(
                name: "SAddress",
                table: "TblShippers",
                newName: "Saddress");

            migrationBuilder.RenameColumn(
                name: "SPerson_in_charge",
                table: "TblShippers",
                newName: "SpersonInCharge");

            migrationBuilder.RenameColumn(
                name: "POL",
                table: "TblJobs",
                newName: "Pol");

            migrationBuilder.RenameColumn(
                name: "PODis",
                table: "TblJobs",
                newName: "Podis");

            migrationBuilder.RenameColumn(
                name: "PODel",
                table: "TblJobs",
                newName: "Podel");

            migrationBuilder.RenameColumn(
                name: "POD",
                table: "TblJobs",
                newName: "Pod");

            migrationBuilder.RenameColumn(
                name: "MBL",
                table: "TblJobs",
                newName: "Mbl");

            migrationBuilder.RenameColumn(
                name: "ETD",
                table: "TblJobs",
                newName: "Etd");

            migrationBuilder.RenameColumn(
                name: "ETA",
                table: "TblJobs",
                newName: "Eta");

            migrationBuilder.RenameColumn(
                name: "Voyage_name",
                table: "TblJobs",
                newName: "VoyageName");

            migrationBuilder.RenameColumn(
                name: "Vessel_name",
                table: "TblJobs",
                newName: "VesselName");

            migrationBuilder.RenameColumn(
                name: "Use_time",
                table: "TblJobs",
                newName: "UseTime");

            migrationBuilder.RenameColumn(
                name: "Pre_Cariage_by",
                table: "TblJobs",
                newName: "PreCariageBy");

            migrationBuilder.RenameColumn(
                name: "OnBoard_dateM",
                table: "TblJobs",
                newName: "OnBoardDateM");

            migrationBuilder.RenameColumn(
                name: "Job_date",
                table: "TblJobs",
                newName: "JobDate");

            migrationBuilder.RenameColumn(
                name: "Issue_dateM",
                table: "TblJobs",
                newName: "IssueDateM");

            migrationBuilder.RenameColumn(
                name: "Goods_type",
                table: "TblJobs",
                newName: "GoodsType");

            migrationBuilder.RenameColumn(
                name: "Job_ID",
                table: "TblJobs",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "PIC",
                table: "TblHbls",
                newName: "Pic");

            migrationBuilder.RenameColumn(
                name: "CNEE",
                table: "TblHbls",
                newName: "Cnee");

            migrationBuilder.RenameColumn(
                name: "HBL",
                table: "TblHbls",
                newName: "Hbl");

            migrationBuilder.RenameColumn(
                name: "SI_No",
                table: "TblHbls",
                newName: "SiNo");

            migrationBuilder.RenameColumn(
                name: "Request_ID",
                table: "TblHbls",
                newName: "RequestId");

            migrationBuilder.RenameColumn(
                name: "PIC_phone",
                table: "TblHbls",
                newName: "PicPhone");

            migrationBuilder.RenameColumn(
                name: "OnBoard_dateH",
                table: "TblHbls",
                newName: "OnBoardDateH");

            migrationBuilder.RenameColumn(
                name: "Notify_party",
                table: "TblHbls",
                newName: "NotifyParty");

            migrationBuilder.RenameColumn(
                name: "Nom_Free",
                table: "TblHbls",
                newName: "NomFree");

            migrationBuilder.RenameColumn(
                name: "Mark_Nos",
                table: "TblHbls",
                newName: "MarkNos");

            migrationBuilder.RenameColumn(
                name: "Issue_placeH",
                table: "TblHbls",
                newName: "IssuePlaceH");

            migrationBuilder.RenameColumn(
                name: "Issue_dateH",
                table: "TblHbls",
                newName: "IssueDateH");

            migrationBuilder.RenameColumn(
                name: "Invoice_No",
                table: "TblHbls",
                newName: "InvoiceNo");

            migrationBuilder.RenameColumn(
                name: "Gross_weight",
                table: "TblHbls",
                newName: "GrossWeight");

            migrationBuilder.RenameColumn(
                name: "Goods_desciption",
                table: "TblHbls",
                newName: "GoodsDesciption");

            migrationBuilder.RenameColumn(
                name: "Freight_charge",
                table: "TblHbls",
                newName: "FreightCharge");

            migrationBuilder.RenameColumn(
                name: "Freight_Payable",
                table: "TblHbls",
                newName: "FreightPayable");

            migrationBuilder.RenameColumn(
                name: "DO_date",
                table: "TblHbls",
                newName: "DoDate");

            migrationBuilder.RenameColumn(
                name: "Customs_declaration_No",
                table: "TblHbls",
                newName: "CustomsDeclarationNo");

            migrationBuilder.RenameColumn(
                name: "Customer_ID",
                table: "TblHbls",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "Cont_Seal_No",
                table: "TblHbls",
                newName: "ContSealNo");

            migrationBuilder.RenameColumn(
                name: "BL_type",
                table: "TblHbls",
                newName: "BlType");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_HBL_Request_ID",
                table: "TblHbls",
                newName: "IX_TblHbls_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_HBL_Customer_ID",
                table: "TblHbls",
                newName: "IX_TblHbls_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CNEE",
                table: "TblCneeAdds",
                newName: "Cnee");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TblCneeAdds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VCNEE",
                table: "TblCnees",
                newName: "Vcnee");

            migrationBuilder.RenameColumn(
                name: "VAddress",
                table: "TblCnees",
                newName: "Vaddress");

            migrationBuilder.RenameColumn(
                name: "TaxID",
                table: "TblCnees",
                newName: "TaxId");

            migrationBuilder.RenameColumn(
                name: "HAddress",
                table: "TblCnees",
                newName: "Haddress");

            migrationBuilder.RenameColumn(
                name: "CCity",
                table: "TblCnees",
                newName: "Ccity");

            migrationBuilder.RenameColumn(
                name: "CAddress",
                table: "TblCnees",
                newName: "Caddress");

            migrationBuilder.RenameColumn(
                name: "CNEE",
                table: "TblCnees",
                newName: "Cnee");

            migrationBuilder.RenameColumn(
                name: "CPerson_in_charge",
                table: "TblCnees",
                newName: "CpersonInCharge");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierId",
                table: "TblInvoices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HblNavigationHbl",
                table: "TblInvoices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HblNavigationHbl",
                table: "TblConths",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TblSupplierActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupplierId",
                table: "TblSupplierActions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "TblSupplierActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonInCharge",
                table: "TblSupplierActions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Typer",
                table: "TblSuppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "TblSuppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameSup",
                table: "TblSuppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LccFee",
                table: "TblSuppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressSup",
                table: "TblSuppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupplierId",
                table: "TblSuppliers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TaxId",
                table: "TblShippers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Scity",
                table: "TblShippers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Saddress",
                table: "TblShippers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Shipper",
                table: "TblShippers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "SpersonInCharge",
                table: "TblShippers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ycompany",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceofReceipt",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceofDelivery",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pol",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Podis",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Podel",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pod",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mode",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mbl",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Carrier",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Agent",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VoyageName",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VesselName",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PreCariageBy",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GoodsType",
                table: "TblJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                table: "TblJobs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "AgentNavigationCode",
                table: "TblJobs",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrierNavigationCode",
                table: "TblJobs",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Shipper",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pic",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumberofOrigins",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnee",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hbl",
                table: "TblHbls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SiNo",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "TblHbls",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PicPhone",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NotifyParty",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomFree",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MarkNos",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssuePlaceH",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNo",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GoodsDesciption",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreightPayable",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomsDeclarationNo",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContSealNo",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlType",
                table: "TblHbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CneeNavigationCnee",
                table: "TblHbls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipperNavigationShipper",
                table: "TblHbls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "TblCneeAdds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonInCharge",
                table: "TblCneeAdds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnee",
                table: "TblCneeAdds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adds",
                table: "TblCneeAdds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CneeNavigationCnee",
                table: "TblCneeAdds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Vcnee",
                table: "TblCnees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Vaddress",
                table: "TblCnees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxId",
                table: "TblCnees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Haddress",
                table: "TblCnees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ccity",
                table: "TblCnees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caddress",
                table: "TblCnees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnee",
                table: "TblCnees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CpersonInCharge",
                table: "TblCnees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSupplierActions",
                table: "TblSupplierActions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSuppliers",
                table: "TblSuppliers",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblShippers",
                table: "TblShippers",
                column: "Shipper");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblJobs",
                table: "TblJobs",
                column: "JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblHbls",
                table: "TblHbls",
                column: "Hbl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCneeAdds",
                table: "TblCneeAdds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCnees",
                table: "TblCnees",
                column: "Cnee");

            migrationBuilder.CreateIndex(
                name: "IX_TblJobs_AgentNavigationCode",
                table: "TblJobs",
                column: "AgentNavigationCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblJobs_CarrierNavigationCode",
                table: "TblJobs",
                column: "CarrierNavigationCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblHbls_CneeNavigationCnee",
                table: "TblHbls",
                column: "CneeNavigationCnee");

            migrationBuilder.CreateIndex(
                name: "IX_TblHbls_ShipperNavigationShipper",
                table: "TblHbls",
                column: "ShipperNavigationShipper");

            migrationBuilder.CreateIndex(
                name: "IX_TblCneeAdds_CneeNavigationCnee",
                table: "TblCneeAdds",
                column: "CneeNavigationCnee");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCneeAdds_TblCnees_CneeNavigationCnee",
                table: "TblCneeAdds",
                column: "CneeNavigationCnee",
                principalTable: "TblCnees",
                principalColumn: "Cnee");

            migrationBuilder.AddForeignKey(
                name: "FK_TblConths_TblHbls_HblNavigationHbl",
                table: "TblConths",
                column: "HblNavigationHbl",
                principalTable: "TblHbls",
                principalColumn: "Hbl");

            migrationBuilder.AddForeignKey(
                name: "FK_TblHbls_TblCnees_CneeNavigationCnee",
                table: "TblHbls",
                column: "CneeNavigationCnee",
                principalTable: "TblCnees",
                principalColumn: "Cnee");

            migrationBuilder.AddForeignKey(
                name: "FK_TblHbls_TblJobs_RequestId",
                table: "TblHbls",
                column: "RequestId",
                principalTable: "TblJobs",
                principalColumn: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblHbls_TblShippers_ShipperNavigationShipper",
                table: "TblHbls",
                column: "ShipperNavigationShipper",
                principalTable: "TblShippers",
                principalColumn: "Shipper");

            migrationBuilder.AddForeignKey(
                name: "FK_TblHbls_tbl_CUSTOMER_CustomerId",
                table: "TblHbls",
                column: "CustomerId",
                principalTable: "tbl_CUSTOMER",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblInvoices_TblHbls_HblNavigationHbl",
                table: "TblInvoices",
                column: "HblNavigationHbl",
                principalTable: "TblHbls",
                principalColumn: "Hbl");

            migrationBuilder.AddForeignKey(
                name: "FK_TblInvoices_TblSuppliers_SupplierId",
                table: "TblInvoices",
                column: "SupplierId",
                principalTable: "TblSuppliers",
                principalColumn: "SupplierId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TblSupplierActions_TblSuppliers_SupplierId",
                table: "TblSupplierActions",
                column: "SupplierId",
                principalTable: "TblSuppliers",
                principalColumn: "SupplierId");
        }
    }
}
