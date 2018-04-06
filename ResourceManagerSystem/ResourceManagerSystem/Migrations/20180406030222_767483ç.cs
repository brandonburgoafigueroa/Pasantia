using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _767483ç : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InDays",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "InMonths",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "InWeeks",
                table: "Course");

            migrationBuilder.AddColumn<int>(
                name: "TypeDuration",
                table: "Course",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeDuration",
                table: "Course");

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
    }
}
