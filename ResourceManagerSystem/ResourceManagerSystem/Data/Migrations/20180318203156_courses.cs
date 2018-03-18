using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class courses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Course_OrganizingEntityID",
                table: "Course",
                column: "OrganizingEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
