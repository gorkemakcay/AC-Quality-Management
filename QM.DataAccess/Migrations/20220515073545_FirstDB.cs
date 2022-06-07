using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QM.DataAccess.Migrations
{
    public partial class FirstDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    FormType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "FinalQualities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    WorkOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TechnicianName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProjectOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityTechnicianId = table.Column<int>(type: "int", nullable: false),
                    QualityOfficerId = table.Column<int>(type: "int", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AcceptanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LotStatus = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StationNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TestNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EngineersNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductSerialNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RevisionCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalQualities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalQualities_AspNetUsers_QualityOfficerId",
                        column: x => x.QualityOfficerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalQualities_AspNetUsers_QualityTechnicianId",
                        column: x => x.QualityTechnicianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PlannedStartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectCreatorId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    MontageTechnicianId = table.Column<int>(type: "int", nullable: false),
                    QualityTechnicianId = table.Column<int>(type: "int", nullable: false),
                    QualityOfficerId = table.Column<int>(type: "int", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SalesOrderCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PlannedFinishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LotStatus = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StationNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_AspNetUsers_MontageTechnicianId",
                        column: x => x.MontageTechnicianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_AspNetUsers_ProjectCreatorId",
                        column: x => x.ProjectCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_AspNetUsers_QualityOfficerId",
                        column: x => x.QualityOfficerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_AspNetUsers_QualityTechnicianId",
                        column: x => x.QualityTechnicianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FQControls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status0 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control0 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status21 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control21 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status22 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control22 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status23 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control23 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status25 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control25 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status26 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control26 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status27 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control27 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status28 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control28 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status29 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control29 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status30 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control30 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status31 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control31 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status32 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control32 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status33 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control33 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status34 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control34 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status35 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control35 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status36 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Control36 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalQualityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FQControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FQControls_FinalQualities_FinalQualityId",
                        column: x => x.FinalQualityId,
                        principalTable: "FinalQualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevisionExplain = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ReasonForRevision = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IntendedPurpose = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RevisionResult = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RevisionType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RevisionRequestedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FinalQualityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revisions_FinalQualities_FinalQualityId",
                        column: x => x.FinalQualityId,
                        principalTable: "FinalQualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManuelScenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Explain = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    manualControlStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManuelScenarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManuelScenarios_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Explain = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    WorkOrderId = table.Column<int>(type: "int", nullable: true),
                    FinalQualityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_FinalQualities_FinalQualityId",
                        column: x => x.FinalQualityId,
                        principalTable: "FinalQualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductModel = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductSerialCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => new { x.AppUserId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_UserNotifications_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_FinalQualities_QualityOfficerId",
                table: "FinalQualities",
                column: "QualityOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalQualities_QualityTechnicianId",
                table: "FinalQualities",
                column: "QualityTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_FQControls_FinalQualityId",
                table: "FQControls",
                column: "FinalQualityId");

            migrationBuilder.CreateIndex(
                name: "IX_ManuelScenarios_WorkOrderId",
                table: "ManuelScenarios",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FinalQualityId",
                table: "Notifications",
                column: "FinalQualityId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_WorkOrderId",
                table: "Notifications",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WorkOrderId",
                table: "Products",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisions_FinalQualityId",
                table: "Revisions",
                column: "FinalQualityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_MontageTechnicianId",
                table: "WorkOrders",
                column: "MontageTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_OwnerId",
                table: "WorkOrders",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_ProjectCreatorId",
                table: "WorkOrders",
                column: "ProjectCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_QualityOfficerId",
                table: "WorkOrders",
                column: "QualityOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_QualityTechnicianId",
                table: "WorkOrders",
                column: "QualityTechnicianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Documents");

            migrationBuilder.DropTable(
                name: "FQControls");

            migrationBuilder.DropTable(
                name: "ManuelScenarios");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Revisions");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "FinalQualities");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
