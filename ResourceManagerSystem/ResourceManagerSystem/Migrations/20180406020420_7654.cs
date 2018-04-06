using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _7654 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DurationWeek",
                table: "Course",
                newName: "Duration");

            migrationBuilder.AddColumn<bool>(
                name: "HasCertified",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InDays",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InMonths",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InWeeks",
                table: "Course",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasCertified",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "InDays",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "InMonths",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "InWeeks",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Course",
                newName: "DurationWeek");
        }
    }
}
