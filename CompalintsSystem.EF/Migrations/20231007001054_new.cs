using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompalintsSystem.EF.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Governorates",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitileProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSubmeted = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "تحديد وقت ادخال الصف في قاعدية البيانات"),
                    BeneficiarieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Societys",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StagesComplaints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StagesComplaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCompalints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCompalints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCommunications",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(150)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersNameAddType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCommunications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeComplaints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(150)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersNameAddType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeComplaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directorates",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directorates_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectorates",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectorates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectorates_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    DirectorateId = table.Column<int>(type: "int", nullable: false),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: true),
                    ProfilePicture = table.Column<string>(type: "varchar(250)", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    originatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Societys_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "Identity",
                        principalTable: "Societys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_User_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Identity",
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
                        name: "FK_AspNetUserClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Identity",
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
                        name: "FK_AspNetUserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Identity",
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
                        name: "FK_AspNetUserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadsComplaintes",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeComplaintId = table.Column<int>(type: "int", nullable: false),
                    DescComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: true),
                    StatusCompalintId = table.Column<int>(type: "int", nullable: false),
                    StagesComplaintId = table.Column<int>(type: "int", nullable: false),
                    PropBeneficiarie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    DirectorateId = table.Column<int>(type: "int", nullable: false),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadsComplaintes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Societys_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "Identity",
                        principalTable: "Societys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_StagesComplaints_StagesComplaintId",
                        column: x => x.StagesComplaintId,
                        principalSchema: "Identity",
                        principalTable: "StagesComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_StatusCompalints_StatusCompalintId",
                        column: x => x.StatusCompalintId,
                        principalSchema: "Identity",
                        principalTable: "StatusCompalints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_TypeComplaints_TypeComplaintId",
                        column: x => x.TypeComplaintId,
                        principalSchema: "Identity",
                        principalTable: "TypeComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_User_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersCommunications",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenfId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenfName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenfPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    DirectorateId = table.Column<int>(type: "int", nullable: false),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCommuncationId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCommunications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_TypeCommunications_TypeCommuncationId",
                        column: x => x.TypeCommuncationId,
                        principalSchema: "Identity",
                        principalTable: "TypeCommunications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compalints_Solutions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UploadsComplainteId = table.Column<int>(type: "int", nullable: false),
                    SolutionProvName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionProvIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentSolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSolution = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compalints_Solutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compalints_Solutions_UploadsComplaintes_UploadsComplainteId",
                        column: x => x.UploadsComplainteId,
                        principalSchema: "Identity",
                        principalTable: "UploadsComplaintes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compalints_Solutions_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintsRejecteds",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UploadsComplainteId = table.Column<int>(type: "int", nullable: false),
                    RejectedProvName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectedUserProvIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSolution = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintsRejecteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintsRejecteds_UploadsComplaintes_UploadsComplainteId",
                        column: x => x.UploadsComplainteId,
                        principalSchema: "Identity",
                        principalTable: "UploadsComplaintes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplaintsRejecteds_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpComplaintCauses",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UploadsComplainteId = table.Column<int>(type: "int", nullable: false),
                    UpProvName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpUserProvIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cause = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpComplaintCauses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpComplaintCauses_UploadsComplaintes_UploadsComplainteId",
                        column: x => x.UploadsComplainteId,
                        principalSchema: "Identity",
                        principalTable: "UploadsComplaintes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpComplaintCauses_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fdc76e6-4033-4a6c-805e-607be8880c2f", null, "cbc5146c-3199-4fee-a4a5-18a953388455", "Beneficiarie", "BENEFICIARIE" },
                    { "0fdebcbd-35ca-486d-91c9-7eab0ee1b617", null, "9ed34f01-5768-4103-8126-48beb2eee6c3", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "76946058-cefd-4e0c-a61d-337d727b0be9", null, "e848451f-aa65-4ccd-90f6-64a551a659d6", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "3915ec10-1b35-433c-ae92-6ca46803a4ea", null, "95ed2dc2-77da-493e-8b43-2233245ed5d3", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "d496e687-a87f-4d63-803b-9aa927cf31c2", null, "d08958d6-9047-4f2b-b278-b3ed6883e7ee", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Governorates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "صنعاء" },
                    { 2, " تعز" },
                    { 3, "الحديدة" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Societys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "جمعية الالبان" },
                    { 1, "جمعية البن" },
                    { 3, "جمعية الحبوب" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "StagesComplaints",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "العزلة" },
                    { 2, "المديرية" },
                    { 3, "المحافظة" },
                    { 4, "الإتحاد العام" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "StatusCompalints",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "مرفوعة" },
                    { 4, "معلقة" },
                    { 3, "مرفوضة" },
                    { 1, "جديدة" },
                    { 2, "محلولة" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeCommunications",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 10, 7, 3, 10, 53, 265, DateTimeKind.Local).AddTicks(9688), "تلاعب بالحلول", null, "قيمة افتراضية من النضام" },
                    { 1, new DateTime(2023, 10, 7, 3, 10, 53, 265, DateTimeKind.Local).AddTicks(9669), "تماطل", null, "قيمة افتراضية من النضام" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 7, 3, 10, 53, 266, DateTimeKind.Local).AddTicks(8444), "زراعية", null, "قيمة افتراضية من النضام" },
                    { 2, new DateTime(2023, 10, 7, 3, 10, 53, 266, DateTimeKind.Local).AddTicks(8862), "فساد", null, "قيمة افتراضية من النضام" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Directorates",
                columns: new[] { "Id", "GovernorateId", "Name" },
                values: new object[,]
                {
                    { 3, 1, "همدان" },
                    { 4, 1, "الحيمة" },
                    { 1, 2, "شرعب السلام" },
                    { 2, 2, "شرعب الرونة" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "SubDirectorates",
                columns: new[] { "Id", "DirectorateId", "Name" },
                values: new object[,]
                {
                    { 3, 3, " بني سعد" },
                    { 4, 4, " الاحبوب" },
                    { 5, 4, "غوبر" },
                    { 1, 1, " القفاعة" },
                    { 2, 1, " المخلاف" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Identity",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_ApplicationUserId",
                schema: "Identity",
                table: "AspNetRoles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Identity",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Identity",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_UploadsComplainteId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "UploadsComplainteId");

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_UserId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintsRejecteds_UploadsComplainteId",
                schema: "Identity",
                table: "ComplaintsRejecteds",
                column: "UploadsComplainteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintsRejecteds_UserId",
                schema: "Identity",
                table: "ComplaintsRejecteds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Directorates_GovernorateId",
                schema: "Identity",
                table: "Directorates",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectorates_DirectorateId",
                schema: "Identity",
                table: "SubDirectorates",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UpComplaintCauses_UploadsComplainteId",
                schema: "Identity",
                table: "UpComplaintCauses",
                column: "UploadsComplainteId");

            migrationBuilder.CreateIndex(
                name: "IX_UpComplaintCauses_UserId",
                schema: "Identity",
                table: "UpComplaintCauses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_ApplicationUserId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_DirectorateId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_GovernorateId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_SocietyId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_StagesComplaintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "StagesComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_StatusCompalintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "StatusCompalintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_SubDirectorateId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_TypeComplaintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "TypeComplaintId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_DirectorateId",
                schema: "Identity",
                table: "User",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GovernorateId",
                schema: "Identity",
                table: "User",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SocietyId",
                schema: "Identity",
                table: "User",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SubDirectorateId",
                schema: "Identity",
                table: "User",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_DirectorateId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_GovernorateId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_SubDirectorateId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_TypeCommuncationId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "TypeCommuncationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_UserId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Compalints_Solutions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ComplaintsRejecteds",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Proposals",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UpComplaintCauses",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersCommunications",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UploadsComplaintes",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TypeCommunications",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "StagesComplaints",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "StatusCompalints",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TypeComplaints",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Societys",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SubDirectorates",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Directorates",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Governorates",
                schema: "Identity");
        }
    }
}
