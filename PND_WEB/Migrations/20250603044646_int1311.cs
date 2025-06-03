using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class int1311 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AGENT",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Agent_name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Agent_namekd = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Agent_add = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENT", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Staff_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BL_TYPE",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BL_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BL_TYPE", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "CARRIER",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Carrier_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Carrier_namekd = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Carier_add = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARRIER", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPORT",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PORT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPORT", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "CURRENCY",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Curr_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURRENCY", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "FEE",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FEE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UNIT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEE", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "GOODS_TYPE",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GT_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GOODS_TYPE", x => x.CODE);
                });

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

            migrationBuilder.CreateTable(
                name: "INVOICE_TYPE",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name_type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICE_TYPE", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Job_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KINDOFPACKAGES",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Package_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Packages_description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KINDOFPACKAGES", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "MODE",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODE", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    QuotationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qsatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CusTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CusContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valid = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Term = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commodity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.QuotationId);
                });

            migrationBuilder.CreateTable(
                name: "SOURSE",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SOUR_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOURSE", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CNEE",
                columns: table => new
                {
                    CNEE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VCNEE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    VAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CPerson_in_charge = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TaxID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CNEE", x => x.CNEE);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CUSTOMER",
                columns: table => new
                {
                    Customer_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Company_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Company_Namekd = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Com_Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Com_Addresskd = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Duty_Person = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CUSTOMER", x => x.Customer_ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_HBL_CHARGES",
                columns: table => new
                {
                    Charge_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Supplier_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Customer_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ser_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ser_Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ser_Quantity = table.Column<float>(type: "real", nullable: true),
                    Ser_Price = table.Column<float>(type: "real", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Exchange_rate = table.Column<float>(type: "real", nullable: true),
                    Ser_VAT = table.Column<float>(type: "real", nullable: true),
                    M_VAT = table.Column<float>(type: "real", nullable: true),
                    Checked = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNo = table.Column<string>(name: "Invoice No", type: "nvarchar(max)", nullable: true),
                    Buy = table.Column<bool>(type: "bit", nullable: true),
                    Sell = table.Column<bool>(type: "bit", nullable: true),
                    Cont = table.Column<bool>(type: "bit", nullable: true),
                    Behalf = table.Column<bool>(type: "bit", nullable: true),
                    HBL_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HBL_CHARGES", x => x.Charge_ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_HSCODE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HS_CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mo_ta_hang_hoaV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mo_ta_hang_hoaE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Don_vi_tinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Thue_NK_TT = table.Column<double>(type: "float", nullable: true),
                    Thue_NK_UD = table.Column<double>(type: "float", nullable: true),
                    Thue_VAT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Acfta = table.Column<double>(type: "float", nullable: true),
                    Atiga = table.Column<double>(type: "float", nullable: true),
                    Ajcep = table.Column<double>(type: "float", nullable: true),
                    Vjepa = table.Column<double>(type: "float", nullable: true),
                    Akfta = table.Column<double>(type: "float", nullable: true),
                    Aanzfta = table.Column<double>(type: "float", nullable: true),
                    Aifta = table.Column<double>(type: "float", nullable: true),
                    Vkfta = table.Column<double>(type: "float", nullable: true),
                    Vcfta = table.Column<double>(type: "float", nullable: true),
                    VN_EAEU = table.Column<double>(type: "float", nullable: true),
                    Cptpp = table.Column<double>(type: "float", nullable: true),
                    Ahkfta = table.Column<double>(type: "float", nullable: true),
                    Vncu = table.Column<double>(type: "float", nullable: true),
                    Evfta = table.Column<double>(type: "float", nullable: true),
                    Ukvfta = table.Column<double>(type: "float", nullable: true),
                    VN_LAO = table.Column<double>(type: "float", nullable: true),
                    RCEPT_A = table.Column<double>(type: "float", nullable: true),
                    RCEPT_B = table.Column<double>(type: "float", nullable: true),
                    RCEPT_C = table.Column<double>(type: "float", nullable: true),
                    RCEPT_D = table.Column<double>(type: "float", nullable: true),
                    RCEPT_E = table.Column<double>(type: "float", nullable: true),
                    RCEPT_F = table.Column<double>(type: "float", nullable: true),
                    Ttdb = table.Column<double>(type: "float", nullable: true),
                    Xk = table.Column<double>(type: "float", nullable: true),
                    Xkcptpp = table.Column<double>(type: "float", nullable: true),
                    Xkev = table.Column<double>(type: "float", nullable: true),
                    Xkukv = table.Column<double>(type: "float", nullable: true),
                    Thue_BVMT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Chinh_sach_hang_hoa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Giam_VAT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Chi_tiet_giam_VAT = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Mo_ta_khong_dau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ghi_chu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ghi_chu_khong_dau = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HSCODE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SHIPPER",
                columns: table => new
                {
                    Shipper = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SPerson_in_charge = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TaxID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SHIPPER", x => x.Shipper);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SUPPLIER",
                columns: table => new
                {
                    Supplier_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name_sup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Typer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address_sup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LCC_Fee = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SUPPLIER", x => x.Supplier_ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TUTT",
                columns: table => new
                {
                    SoTUTT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NhanvienTUTT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Noi_dung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    xacnhanduyet = table.Column<bool>(type: "bit", nullable: true),
                    ketoan = table.Column<bool>(type: "bit", nullable: true),
                    ceo = table.Column<bool>(type: "bit", nullable: true),
                    TU = table.Column<bool>(type: "bit", nullable: true),
                    TT = table.Column<bool>(type: "bit", nullable: true),
                    Ghi_chu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TUTT", x => x.SoTUTT);
                });

            migrationBuilder.CreateTable(
                name: "UNIT",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Unit_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNIT", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "AGENT_ACTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Person_in_charge = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone_number = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENT_ACTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AGENT_ACTION_AGENT_CODE",
                        column: x => x.CODE,
                        principalTable: "AGENT",
                        principalColumn: "CODE");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CARRIER_ACTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Person_in_charge = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone_number = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LCC_Fee = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARRIER_ACTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CARRIER_ACTION_CARRIER_CODE",
                        column: x => x.CODE,
                        principalTable: "CARRIER",
                        principalColumn: "CODE");
                });

            migrationBuilder.CreateTable(
                name: "tbl_JOB",
                columns: table => new
                {
                    Job_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Goods_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Job_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MBL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Issue_dateM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OnBoard_dateM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Vessel_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Voyage_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    POL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    POD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PODel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PODis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PlaceofReceipt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PlaceofDelivery = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pre_Cariage_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ETD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Agent = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ycompany = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    YunLock = table.Column<int>(type: "int", nullable: true),
                    Use_time = table.Column<int>(type: "int", nullable: true),
                    JobOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_JOB", x => x.Job_ID);
                    table.ForeignKey(
                        name: "FK_tbl_JOB_AGENT_Agent",
                        column: x => x.Agent,
                        principalTable: "AGENT",
                        principalColumn: "CODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_JOB_CARRIER_Carrier",
                        column: x => x.Carrier,
                        principalTable: "CARRIER",
                        principalColumn: "CODE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INVOICE_CHARGE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "QuotationsCharges",
                columns: table => new
                {
                    ChargeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChargeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationsCharges", x => x.ChargeId);
                    table.ForeignKey(
                        name: "FK_QuotationsCharges_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "QuotationId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_CNEE_ADD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adds = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Place = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PersonInCharge = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CNEE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CNEE_ADD", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_CNEE_ADD_tbl_CNEE_CNEE",
                        column: x => x.CNEE,
                        principalTable: "tbl_CNEE",
                        principalColumn: "CNEE");
                });

            migrationBuilder.CreateTable(
                name: "tbl_BOOKING_CONFIRM",
                columns: table => new
                {
                    Booking_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Customer_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Booking_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Good_Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ETD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    POL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    POD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Vessel_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Container_Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Container_Quantity = table.Column<int>(type: "int", nullable: true),
                    Flight_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Airline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Package_Quantity = table.Column<int>(type: "int", nullable: true),
                    Gross_Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Chargeable_Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cargo_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIC_company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quotation_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNEE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Shipper = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_BOOKING_CONFIRM", x => x.Booking_ID);
                    table.ForeignKey(
                        name: "FK_tbl_BOOKING_CONFIRM_tbl_CUSTOMER_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "tbl_CUSTOMER",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SUPPLIER_ACTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Person_in_charge = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone_number = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SUPPLIER_ACTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_SUPPLIER_ACTION_tbl_SUPPLIER_Supplier_ID",
                        column: x => x.Supplier_ID,
                        principalTable: "tbl_SUPPLIER",
                        principalColumn: "Supplier_ID");
                });

            migrationBuilder.CreateTable(
                name: "TblTuttsPhi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHoaDon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TenPhi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoTien = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoTUTT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTuttsPhi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TblTuttsPhi_tbl_TUTT_SoTUTT",
                        column: x => x.SoTUTT,
                        principalTable: "tbl_TUTT",
                        principalColumn: "SoTUTT");
                });

            migrationBuilder.CreateTable(
                name: "tbl_HBL",
                columns: table => new
                {
                    HBL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Request_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Issue_placeH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Issue_dateH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OnBoard_dateH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Customer_ID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Shipper = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CNEE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Notify_party = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BL_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nom_Free = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cont_Seal_No = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Volume = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Goods_desciption = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Gross_weight = table.Column<double>(type: "float", nullable: true),
                    Tonnage = table.Column<double>(type: "float", nullable: true),
                    Customs_declaration_No = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Invoice_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumberofOrigins = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Freight_Payable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mark_Nos = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Freight_charge = table.Column<bool>(type: "bit", nullable: true),
                    Prepaid = table.Column<bool>(type: "bit", nullable: true),
                    Collect = table.Column<bool>(type: "bit", nullable: true),
                    SI_No = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PIC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DO_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PIC_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HBL", x => x.HBL);
                    table.ForeignKey(
                        name: "FK_tbl_HBL_tbl_CNEE_CNEE",
                        column: x => x.CNEE,
                        principalTable: "tbl_CNEE",
                        principalColumn: "CNEE");
                    table.ForeignKey(
                        name: "FK_tbl_HBL_tbl_CUSTOMER_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "tbl_CUSTOMER",
                        principalColumn: "Customer_ID");
                    table.ForeignKey(
                        name: "FK_tbl_HBL_tbl_JOB_Request_ID",
                        column: x => x.Request_ID,
                        principalTable: "tbl_JOB",
                        principalColumn: "Job_ID");
                    table.ForeignKey(
                        name: "FK_tbl_HBL_tbl_SHIPPER_Shipper",
                        column: x => x.Shipper,
                        principalTable: "tbl_SHIPPER",
                        principalColumn: "Shipper");
                });

            migrationBuilder.CreateTable(
                name: "tbl_INVOICE",
                columns: table => new
                {
                    Debit_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Supplier_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Invoice_type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Debit_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Payment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Invoice_No = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Invoice_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Buy = table.Column<bool>(type: "bit", nullable: true),
                    Sell = table.Column<bool>(type: "bit", nullable: true),
                    Cont = table.Column<bool>(type: "bit", nullable: true),
                    HBL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HBL1 = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_INVOICE", x => x.Debit_ID);
                    table.ForeignKey(
                        name: "FK_tbl_INVOICE_tbl_HBL_HBL1",
                        column: x => x.HBL1,
                        principalTable: "tbl_HBL",
                        principalColumn: "HBL");
                    table.ForeignKey(
                        name: "FK_tbl_INVOICE_tbl_SUPPLIER_Supplier_ID",
                        column: x => x.Supplier_ID,
                        principalTable: "tbl_SUPPLIER",
                        principalColumn: "Supplier_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblConths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hbl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContQuantity = table.Column<int>(type: "int", nullable: true),
                    ContType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SealNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeight = table.Column<double>(type: "float", nullable: false),
                    Cmb = table.Column<double>(type: "float", nullable: false),
                    GoodsQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsKind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsDepcription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HblNavigationHbl = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblConths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblConths_tbl_HBL_HblNavigationHbl",
                        column: x => x.HblNavigationHbl,
                        principalTable: "tbl_HBL",
                        principalColumn: "HBL");
                });

            migrationBuilder.CreateTable(
                name: "tbl_CHARGES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Debit_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
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
                    table.PrimaryKey("PK_tbl_CHARGES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_CHARGES_tbl_INVOICE_Debit_ID",
                        column: x => x.Debit_ID,
                        principalTable: "tbl_INVOICE",
                        principalColumn: "Debit_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENT_ACTION_CODE",
                table: "AGENT_ACTION",
                column: "CODE");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CARRIER_ACTION_CODE",
                table: "CARRIER_ACTION",
                column: "CODE");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICE_CHARGE_Invoice_ID",
                table: "INVOICE_CHARGE",
                column: "Invoice_ID");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationsCharges_QuotationId",
                table: "QuotationsCharges",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BOOKING_CONFIRM_Customer_ID",
                table: "tbl_BOOKING_CONFIRM",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CHARGES_Debit_ID",
                table: "tbl_CHARGES",
                column: "Debit_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CNEE_ADD_CNEE",
                table: "tbl_CNEE_ADD",
                column: "CNEE");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HBL_CNEE",
                table: "tbl_HBL",
                column: "CNEE");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HBL_Customer_ID",
                table: "tbl_HBL",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HBL_Request_ID",
                table: "tbl_HBL",
                column: "Request_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HBL_Shipper",
                table: "tbl_HBL",
                column: "Shipper");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_INVOICE_HBL1",
                table: "tbl_INVOICE",
                column: "HBL1");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_INVOICE_Supplier_ID",
                table: "tbl_INVOICE",
                column: "Supplier_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_JOB_Agent",
                table: "tbl_JOB",
                column: "Agent");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_JOB_Carrier",
                table: "tbl_JOB",
                column: "Carrier");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SUPPLIER_ACTION_Supplier_ID",
                table: "tbl_SUPPLIER_ACTION",
                column: "Supplier_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TblConths_HblNavigationHbl",
                table: "TblConths",
                column: "HblNavigationHbl");

            migrationBuilder.CreateIndex(
                name: "IX_TblTuttsPhi_SoTUTT",
                table: "TblTuttsPhi",
                column: "SoTUTT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENT_ACTION");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BL_TYPE");

            migrationBuilder.DropTable(
                name: "CARRIER_ACTION");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "CPORT");

            migrationBuilder.DropTable(
                name: "CURRENCY");

            migrationBuilder.DropTable(
                name: "FEE");

            migrationBuilder.DropTable(
                name: "GOODS_TYPE");

            migrationBuilder.DropTable(
                name: "INVOICE_CHARGE");

            migrationBuilder.DropTable(
                name: "INVOICE_TYPE");

            migrationBuilder.DropTable(
                name: "Job_User");

            migrationBuilder.DropTable(
                name: "KINDOFPACKAGES");

            migrationBuilder.DropTable(
                name: "MODE");

            migrationBuilder.DropTable(
                name: "QuotationsCharges");

            migrationBuilder.DropTable(
                name: "SOURSE");

            migrationBuilder.DropTable(
                name: "tbl_BOOKING_CONFIRM");

            migrationBuilder.DropTable(
                name: "tbl_CHARGES");

            migrationBuilder.DropTable(
                name: "tbl_CNEE_ADD");

            migrationBuilder.DropTable(
                name: "tbl_HBL_CHARGES");

            migrationBuilder.DropTable(
                name: "tbl_HSCODE");

            migrationBuilder.DropTable(
                name: "tbl_SUPPLIER_ACTION");

            migrationBuilder.DropTable(
                name: "TblConths");

            migrationBuilder.DropTable(
                name: "TblTuttsPhi");

            migrationBuilder.DropTable(
                name: "UNIT");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "INVOICE");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "tbl_INVOICE");

            migrationBuilder.DropTable(
                name: "tbl_TUTT");

            migrationBuilder.DropTable(
                name: "tbl_HBL");

            migrationBuilder.DropTable(
                name: "tbl_SUPPLIER");

            migrationBuilder.DropTable(
                name: "tbl_CNEE");

            migrationBuilder.DropTable(
                name: "tbl_CUSTOMER");

            migrationBuilder.DropTable(
                name: "tbl_JOB");

            migrationBuilder.DropTable(
                name: "tbl_SHIPPER");

            migrationBuilder.DropTable(
                name: "AGENT");

            migrationBuilder.DropTable(
                name: "CARRIER");
        }
    }
}
