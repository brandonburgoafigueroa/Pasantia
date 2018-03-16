using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Data.Migrations
{
    public partial class EMPLOADMINCOLLECTREPREPP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "REPPS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Color = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPPS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Operative",
                columns: table => new
                {
                    AdministrativeName = table.Column<string>(nullable: true),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operative", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Operative_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CollectionsREPP",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperativeID = table.Column<int>(nullable: true),
                    ReppID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionsREPP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CollectionsREPP_Operative_OperativeID",
                        column: x => x.OperativeID,
                        principalTable: "Operative",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CollectionsREPP_REPPS_ReppID",
                        column: x => x.ReppID,
                        principalTable: "REPPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    Basic = table.Column<bool>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Ci = table.Column<int>(nullable: false),
                    CivilState = table.Column<int>(nullable: false),
                    Degree = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    HighSchool = table.Column<bool>(nullable: false),
                    HighTechnician = table.Column<bool>(nullable: false),
                    Iliterate = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Mental = table.Column<bool>(nullable: false),
                    MiddleTechnician = table.Column<bool>(nullable: false),
                    Motor = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    PositionID = table.Column<int>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    TypeContrat = table.Column<int>(nullable: false),
                    Visual = table.Column<bool>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Operative_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Operative",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionsREPP_OperativeID",
                table: "CollectionsREPP",
                column: "OperativeID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionsREPP_ReppID",
                table: "CollectionsREPP",
                column: "ReppID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionID",
                table: "Employees",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Operative_RegionID",
                table: "Operative",
                column: "RegionID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CollectionsREPP");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "REPPS");

            migrationBuilder.DropTable(
                name: "Operative");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
