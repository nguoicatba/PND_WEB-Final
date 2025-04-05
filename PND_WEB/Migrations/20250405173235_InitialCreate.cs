using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PND_WEB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentNamekd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Code);
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
                name: "BlTypes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BlName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlTypes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarrierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierNamekd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarierAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Cports",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cports", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fee1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "GoodsTypes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsTypes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Kindofpackages",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackagesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kindofpackages", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Modes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modes", x => x.Code);
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
                name: "Sourses",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SourName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sourses", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CUSTOMER",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CompanyNamekd = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ComAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ComAddresskd = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DutyPerson = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CUSTOMER", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TblCnees",
                columns: table => new
                {
                    Cnee = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Vcnee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ccity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpersonInCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Haddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCnees", x => x.Cnee);
                });

            migrationBuilder.CreateTable(
                name: "TblHscodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HsCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MoTaHangHoaV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTaHangHoaE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThueNkTt = table.Column<double>(type: "float", nullable: true),
                    ThueNkUd = table.Column<double>(type: "float", nullable: true),
                    ThueVat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acfta = table.Column<double>(type: "float", nullable: true),
                    Atiga = table.Column<double>(type: "float", nullable: true),
                    Ajcep = table.Column<double>(type: "float", nullable: true),
                    Vjepa = table.Column<double>(type: "float", nullable: true),
                    Akfta = table.Column<double>(type: "float", nullable: true),
                    Aanzfta = table.Column<double>(type: "float", nullable: true),
                    Aifta = table.Column<double>(type: "float", nullable: true),
                    Vkfta = table.Column<double>(type: "float", nullable: true),
                    Vcfta = table.Column<double>(type: "float", nullable: true),
                    VnEaeu = table.Column<double>(type: "float", nullable: true),
                    Cptpp = table.Column<double>(type: "float", nullable: true),
                    Ahkfta = table.Column<double>(type: "float", nullable: true),
                    Vncu = table.Column<double>(type: "float", nullable: true),
                    Evfta = table.Column<double>(type: "float", nullable: true),
                    Ukvfta = table.Column<double>(type: "float", nullable: true),
                    VnLao = table.Column<double>(type: "float", nullable: true),
                    RceptA = table.Column<double>(type: "float", nullable: true),
                    RceptB = table.Column<double>(type: "float", nullable: true),
                    RceptC = table.Column<double>(type: "float", nullable: true),
                    RceptD = table.Column<double>(type: "float", nullable: true),
                    RceptE = table.Column<double>(type: "float", nullable: true),
                    RceptF = table.Column<double>(type: "float", nullable: true),
                    Ttdb = table.Column<double>(type: "float", nullable: true),
                    Xk = table.Column<double>(type: "float", nullable: true),
                    Xkcptpp = table.Column<double>(type: "float", nullable: true),
                    Xkev = table.Column<double>(type: "float", nullable: true),
                    Xkukv = table.Column<double>(type: "float", nullable: true),
                    ThueBvmt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChinhSachHangHoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiamVat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChiTietGiamVat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTaKhongDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChuKhongDau = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblHscodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblShippers",
                columns: table => new
                {
                    Shipper = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Saddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpersonInCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblShippers", x => x.Shipper);
                });

            migrationBuilder.CreateTable(
                name: "TblSuppliers",
                columns: table => new
                {
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameSup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Typer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressSup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LccFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSuppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "TblTutts",
                columns: table => new
                {
                    SoTutt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NhanvienTutt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xacnhanduyet = table.Column<bool>(type: "bit", nullable: true),
                    Ketoan = table.Column<bool>(type: "bit", nullable: true),
                    Ceo = table.Column<bool>(type: "bit", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTutts", x => x.SoTutt);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AgentActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonInCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeNavigationCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentActions_Agents_CodeNavigationCode",
                        column: x => x.CodeNavigationCode,
                        principalTable: "Agents",
                        principalColumn: "Code");
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
                name: "CarrierActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonInCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LccFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeNavigationCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrierActions_Carriers_CodeNavigationCode",
                        column: x => x.CodeNavigationCode,
                        principalTable: "Carriers",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "TblJobs",
                columns: table => new
                {
                    JobId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoodsType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mbl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDateM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OnBoardDateM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VesselName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoyageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Podel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Podis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceofReceipt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceofDelivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreCariageBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ycompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YunLock = table.Column<int>(type: "int", nullable: true),
                    UseTime = table.Column<int>(type: "int", nullable: true),
                    AgentNavigationCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarrierNavigationCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblJobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_TblJobs_Agents_AgentNavigationCode",
                        column: x => x.AgentNavigationCode,
                        principalTable: "Agents",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_TblJobs_Carriers_CarrierNavigationCode",
                        column: x => x.CarrierNavigationCode,
                        principalTable: "Carriers",
                        principalColumn: "Code");
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
                name: "TblCneeAdds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonInCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CneeNavigationCnee = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCneeAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCneeAdds_TblCnees_CneeNavigationCnee",
                        column: x => x.CneeNavigationCnee,
                        principalTable: "TblCnees",
                        principalColumn: "Cnee");
                });

            migrationBuilder.CreateTable(
                name: "TblSupplierActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PersonInCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSupplierActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSupplierActions_TblSuppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TblSuppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "TblTuttsPhi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenPhi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tu = table.Column<bool>(type: "bit", nullable: true),
                    Tt = table.Column<bool>(type: "bit", nullable: true),
                    SoTien = table.Column<double>(type: "float", nullable: true),
                    NghiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTutt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTuttNavigationSoTutt = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTuttsPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblTuttsPhi_TblTutts_SoTuttNavigationSoTutt",
                        column: x => x.SoTuttNavigationSoTutt,
                        principalTable: "TblTutts",
                        principalColumn: "SoTutt");
                });

            migrationBuilder.CreateTable(
                name: "TblHbls",
                columns: table => new
                {
                    Hbl = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IssuePlaceH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDateH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OnBoardDateH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Shipper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotifyParty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomFree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContSealNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsDesciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossWeight = table.Column<double>(type: "float", nullable: true),
                    Tonnage = table.Column<double>(type: "float", nullable: true),
                    CustomsDeclarationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberofOrigins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreightPayable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkNos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreightCharge = table.Column<bool>(type: "bit", nullable: true),
                    Prepaid = table.Column<bool>(type: "bit", nullable: true),
                    Collect = table.Column<bool>(type: "bit", nullable: true),
                    SiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PicPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CneeNavigationCnee = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShipperNavigationShipper = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblHbls", x => x.Hbl);
                    table.ForeignKey(
                        name: "FK_TblHbls_TblCnees_CneeNavigationCnee",
                        column: x => x.CneeNavigationCnee,
                        principalTable: "TblCnees",
                        principalColumn: "Cnee");
                    table.ForeignKey(
                        name: "FK_TblHbls_TblJobs_RequestId",
                        column: x => x.RequestId,
                        principalTable: "TblJobs",
                        principalColumn: "JobId");
                    table.ForeignKey(
                        name: "FK_TblHbls_TblShippers_ShipperNavigationShipper",
                        column: x => x.ShipperNavigationShipper,
                        principalTable: "TblShippers",
                        principalColumn: "Shipper");
                    table.ForeignKey(
                        name: "FK_TblHbls_tbl_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tbl_CUSTOMER",
                        principalColumn: "CustomerId");
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
                    GrossWeight = table.Column<double>(type: "float", nullable: true),
                    Cmb = table.Column<double>(type: "float", nullable: true),
                    GoodsQuantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsDepcription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HblNavigationHbl = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblConths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblConths_TblHbls_HblNavigationHbl",
                        column: x => x.HblNavigationHbl,
                        principalTable: "TblHbls",
                        principalColumn: "Hbl");
                });

            migrationBuilder.CreateTable(
                name: "TblInvoices",
                columns: table => new
                {
                    DebitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Hbl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HblNavigationHbl = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInvoices", x => x.DebitId);
                    table.ForeignKey(
                        name: "FK_TblInvoices_TblHbls_HblNavigationHbl",
                        column: x => x.HblNavigationHbl,
                        principalTable: "TblHbls",
                        principalColumn: "Hbl");
                    table.ForeignKey(
                        name: "FK_TblInvoices_TblSuppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TblSuppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "TblCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExchangeRate = table.Column<float>(type: "real", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerPrice = table.Column<float>(type: "real", nullable: true),
                    SerQuantity = table.Column<float>(type: "real", nullable: true),
                    SerUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerVat = table.Column<float>(type: "real", nullable: true),
                    MVat = table.Column<float>(type: "real", nullable: true),
                    Buy = table.Column<bool>(type: "bit", nullable: true),
                    Sell = table.Column<bool>(type: "bit", nullable: true),
                    Cont = table.Column<bool>(type: "bit", nullable: true),
                    Checked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCharges_TblInvoices_DebitId",
                        column: x => x.DebitId,
                        principalTable: "TblInvoices",
                        principalColumn: "DebitId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentActions_CodeNavigationCode",
                table: "AgentActions",
                column: "CodeNavigationCode");

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
                name: "IX_CarrierActions_CodeNavigationCode",
                table: "CarrierActions",
                column: "CodeNavigationCode");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationsCharges_QuotationId",
                table: "QuotationsCharges",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCharges_DebitId",
                table: "TblCharges",
                column: "DebitId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCneeAdds_CneeNavigationCnee",
                table: "TblCneeAdds",
                column: "CneeNavigationCnee");

            migrationBuilder.CreateIndex(
                name: "IX_TblConths_HblNavigationHbl",
                table: "TblConths",
                column: "HblNavigationHbl");

            migrationBuilder.CreateIndex(
                name: "IX_TblHbls_CneeNavigationCnee",
                table: "TblHbls",
                column: "CneeNavigationCnee");

            migrationBuilder.CreateIndex(
                name: "IX_TblHbls_CustomerId",
                table: "TblHbls",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblHbls_RequestId",
                table: "TblHbls",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TblHbls_ShipperNavigationShipper",
                table: "TblHbls",
                column: "ShipperNavigationShipper");

            migrationBuilder.CreateIndex(
                name: "IX_TblInvoices_HblNavigationHbl",
                table: "TblInvoices",
                column: "HblNavigationHbl");

            migrationBuilder.CreateIndex(
                name: "IX_TblInvoices_SupplierId",
                table: "TblInvoices",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TblJobs_AgentNavigationCode",
                table: "TblJobs",
                column: "AgentNavigationCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblJobs_CarrierNavigationCode",
                table: "TblJobs",
                column: "CarrierNavigationCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblSupplierActions_SupplierId",
                table: "TblSupplierActions",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TblTuttsPhi_SoTuttNavigationSoTutt",
                table: "TblTuttsPhi",
                column: "SoTuttNavigationSoTutt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentActions");

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
                name: "BlTypes");

            migrationBuilder.DropTable(
                name: "CarrierActions");

            migrationBuilder.DropTable(
                name: "Cports");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "GoodsTypes");

            migrationBuilder.DropTable(
                name: "InvoiceTypes");

            migrationBuilder.DropTable(
                name: "Kindofpackages");

            migrationBuilder.DropTable(
                name: "Modes");

            migrationBuilder.DropTable(
                name: "QuotationsCharges");

            migrationBuilder.DropTable(
                name: "Sourses");

            migrationBuilder.DropTable(
                name: "TblCharges");

            migrationBuilder.DropTable(
                name: "TblCneeAdds");

            migrationBuilder.DropTable(
                name: "TblConths");

            migrationBuilder.DropTable(
                name: "TblHscodes");

            migrationBuilder.DropTable(
                name: "TblSupplierActions");

            migrationBuilder.DropTable(
                name: "TblTuttsPhi");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "TblInvoices");

            migrationBuilder.DropTable(
                name: "TblTutts");

            migrationBuilder.DropTable(
                name: "TblHbls");

            migrationBuilder.DropTable(
                name: "TblSuppliers");

            migrationBuilder.DropTable(
                name: "TblCnees");

            migrationBuilder.DropTable(
                name: "TblJobs");

            migrationBuilder.DropTable(
                name: "TblShippers");

            migrationBuilder.DropTable(
                name: "tbl_CUSTOMER");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Carriers");
        }
    }
}
