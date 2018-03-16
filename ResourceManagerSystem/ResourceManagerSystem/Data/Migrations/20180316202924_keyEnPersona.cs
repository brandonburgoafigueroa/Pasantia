using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class keyEnPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdministrativeID = table.Column<int>(nullable: false),
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
                    Sex = table.Column<int>(nullable: false),
                    TypeContrat = table.Column<int>(nullable: false),
                    Visual = table.Column<bool>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Employee_Administrative_AdministrativeID",
                        column: x => x.AdministrativeID,
                        principalTable: "Administrative",
                        principalColumn: "AdministrativeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AdministrativeID",
                table: "Employee",
                column: "AdministrativeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
