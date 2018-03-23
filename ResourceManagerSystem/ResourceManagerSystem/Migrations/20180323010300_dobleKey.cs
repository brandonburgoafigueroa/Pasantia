using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class dobleKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrolment",
                table: "Enrolment");

            migrationBuilder.DropIndex(
                name: "IX_Enrolment_CI",
                table: "Enrolment");

            migrationBuilder.DropIndex(
                name: "IX_Enrolment_CourseID",
                table: "Enrolment");

            migrationBuilder.DropColumn(
                name: "EnrolmentID",
                table: "Enrolment");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Enrolment_CI_CourseID",
                table: "Enrolment",
                columns: new[] { "CI", "CourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrolment",
                table: "Enrolment",
                columns: new[] { "CourseID", "CI" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Enrolment_CI_CourseID",
                table: "Enrolment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrolment",
                table: "Enrolment");

            migrationBuilder.AddColumn<int>(
                name: "EnrolmentID",
                table: "Enrolment",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrolment",
                table: "Enrolment",
                column: "EnrolmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_CI",
                table: "Enrolment",
                column: "CI");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_CourseID",
                table: "Enrolment",
                column: "CourseID");
        }
    }
}
