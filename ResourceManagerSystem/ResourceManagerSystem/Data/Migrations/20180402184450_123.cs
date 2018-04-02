using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrative",
                columns: table => new
                {
                    AdministrativeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrative", x => x.AdministrativeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorName);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "OrganizingEntity",
                columns: table => new
                {
                    OrganizingEntityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    TypeOfEntity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizingEntity", x => x.OrganizingEntityID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeName);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Provider",
                columns: table => new
                {
                    ProviderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    ContactID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ProviderID);
                    table.ForeignKey(
                        name: "FK_Provider_Contact_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contact",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttendanceType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DurationWeek = table.Column<int>(nullable: false),
                    IsExternal = table.Column<bool>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    OrganizingEntityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_OrganizingEntity_OrganizingEntityID",
                        column: x => x.OrganizingEntityID,
                        principalTable: "OrganizingEntity",
                        principalColumn: "OrganizingEntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operative",
                columns: table => new
                {
                    OperativeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdministrativeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RegionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operative", x => x.OperativeID);
                    table.ForeignKey(
                        name: "FK_Operative_Administrative_AdministrativeID",
                        column: x => x.AdministrativeID,
                        principalTable: "Administrative",
                        principalColumn: "AdministrativeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operative_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REPPS",
                columns: table => new
                {
                    ReppID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SizeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPPS", x => x.ReppID);
                    table.ForeignKey(
                        name: "FK_REPPS_Color_ColorName",
                        column: x => x.ColorName,
                        principalTable: "Color",
                        principalColumn: "ColorName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REPPS_Size_SizeName",
                        column: x => x.SizeName,
                        principalTable: "Size",
                        principalColumn: "SizeName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    LotID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProviderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.LotID);
                    table.ForeignKey(
                        name: "FK_Lot_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    CI = table.Column<string>(nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    Basic = table.Column<bool>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CivilState = table.Column<int>(nullable: false),
                    Degree = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    HighSchool = table.Column<bool>(nullable: false),
                    Illiterate = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Mental = table.Column<bool>(nullable: false),
                    MiddleTechnician = table.Column<bool>(nullable: false),
                    Motor = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    OperativeID = table.Column<int>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Visual = table.Column<bool>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.CI);
                    table.ForeignKey(
                        name: "FK_Employee_Operative_OperativeID",
                        column: x => x.OperativeID,
                        principalTable: "Operative",
                        principalColumn: "OperativeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CollectionsREPP",
                columns: table => new
                {
                    CollectionREPPID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperativeID = table.Column<int>(nullable: false),
                    ReppID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionsREPP", x => x.CollectionREPPID);
                    table.ForeignKey(
                        name: "FK_CollectionsREPP_Operative_OperativeID",
                        column: x => x.OperativeID,
                        principalTable: "Operative",
                        principalColumn: "OperativeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionsREPP_REPPS_ReppID",
                        column: x => x.ReppID,
                        principalTable: "REPPS",
                        principalColumn: "ReppID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryModelView",
                columns: table => new
                {
                    DeliveryModelViewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ColorName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LotID = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ReppID = table.Column<int>(nullable: false),
                    SizeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryModelView", x => x.DeliveryModelViewID);
                    table.ForeignKey(
                        name: "FK_DeliveryModelView_Color_ColorName",
                        column: x => x.ColorName,
                        principalTable: "Color",
                        principalColumn: "ColorName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryModelView_REPPS_ReppID",
                        column: x => x.ReppID,
                        principalTable: "REPPS",
                        principalColumn: "ReppID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryModelView_Size_SizeName",
                        column: x => x.SizeName,
                        principalTable: "Size",
                        principalColumn: "SizeName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    ReppID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockID);
                    table.ForeignKey(
                        name: "FK_Stock_REPPS_ReppID",
                        column: x => x.ReppID,
                        principalTable: "REPPS",
                        principalColumn: "ReppID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LotID = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ReppID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryID);
                    table.ForeignKey(
                        name: "FK_Deliveries_Lot_LotID",
                        column: x => x.LotID,
                        principalTable: "Lot",
                        principalColumn: "LotID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_REPPS_ReppID",
                        column: x => x.ReppID,
                        principalTable: "REPPS",
                        principalColumn: "ReppID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrat",
                columns: table => new
                {
                    ContratID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CI = table.Column<string>(nullable: true),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    OperativeID = table.Column<int>(nullable: false),
                    TypeContrat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrat", x => x.ContratID);
                    table.ForeignKey(
                        name: "FK_Contrat_Employee_CI",
                        column: x => x.CI,
                        principalTable: "Employee",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrat_Operative_OperativeID",
                        column: x => x.OperativeID,
                        principalTable: "Operative",
                        principalColumn: "OperativeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeModelView",
                columns: table => new
                {
                    CI = table.Column<string>(nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    Basic = table.Column<bool>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CivilState = table.Column<int>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    Degree = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmployeeCI = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    HighSchool = table.Column<bool>(nullable: false),
                    Illiterate = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Mental = table.Column<bool>(nullable: false),
                    MiddleTechnician = table.Column<bool>(nullable: false),
                    Motor = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    OperativeID = table.Column<int>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    TypeContrat = table.Column<int>(nullable: false),
                    Visual = table.Column<bool>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeModelView", x => x.CI);
                    table.ForeignKey(
                        name: "FK_EmployeModelView_Employee_EmployeeCI",
                        column: x => x.EmployeeCI,
                        principalTable: "Employee",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeModelView_Operative_OperativeID",
                        column: x => x.OperativeID,
                        principalTable: "Operative",
                        principalColumn: "OperativeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrolment",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false),
                    CI = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeCI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolment", x => new { x.CourseID, x.CI });
                    table.UniqueConstraint("AK_Enrolment_CI_CourseID", x => new { x.CI, x.CourseID });
                    table.ForeignKey(
                        name: "FK_Enrolment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolment_Employee_EmployeeCI",
                        column: x => x.EmployeeCI,
                        principalTable: "Employee",
                        principalColumn: "CI",
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
                name: "IX_CollectionsREPP_OperativeID",
                table: "CollectionsREPP",
                column: "OperativeID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionsREPP_ReppID",
                table: "CollectionsREPP",
                column: "ReppID");

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_CI",
                table: "Contrat",
                column: "CI");

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_OperativeID",
                table: "Contrat",
                column: "OperativeID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_OrganizingEntityID",
                table: "Course",
                column: "OrganizingEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_LotID",
                table: "Deliveries",
                column: "LotID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ReppID",
                table: "Deliveries",
                column: "ReppID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryModelView_ColorName",
                table: "DeliveryModelView",
                column: "ColorName");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryModelView_ReppID",
                table: "DeliveryModelView",
                column: "ReppID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryModelView_SizeName",
                table: "DeliveryModelView",
                column: "SizeName");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OperativeID",
                table: "Employee",
                column: "OperativeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeModelView_EmployeeCI",
                table: "EmployeModelView",
                column: "EmployeeCI");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeModelView_OperativeID",
                table: "EmployeModelView",
                column: "OperativeID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_EmployeeCI",
                table: "Enrolment",
                column: "EmployeeCI");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_ProviderID",
                table: "Lot",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Operative_AdministrativeID",
                table: "Operative",
                column: "AdministrativeID");

            migrationBuilder.CreateIndex(
                name: "IX_Operative_RegionID",
                table: "Operative",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_ContactID",
                table: "Provider",
                column: "ContactID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_REPPS_ColorName",
                table: "REPPS",
                column: "ColorName");

            migrationBuilder.CreateIndex(
                name: "IX_REPPS_SizeName",
                table: "REPPS",
                column: "SizeName");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ReppID",
                table: "Stock",
                column: "ReppID");
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
                name: "CollectionsREPP");

            migrationBuilder.DropTable(
                name: "Contrat");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "DeliveryModelView");

            migrationBuilder.DropTable(
                name: "EmployeModelView");

            migrationBuilder.DropTable(
                name: "Enrolment");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Lot");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "REPPS");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "OrganizingEntity");

            migrationBuilder.DropTable(
                name: "Operative");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Administrative");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
