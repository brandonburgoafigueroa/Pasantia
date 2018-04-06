using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _7654234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mental",
                table: "EmployeModelView");

            migrationBuilder.DropColumn(
                name: "Motor",
                table: "EmployeModelView");

            migrationBuilder.DropColumn(
                name: "Mental",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Motor",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Visual",
                table: "EmployeModelView",
                newName: "IsDisabled");

            migrationBuilder.RenameColumn(
                name: "Visual",
                table: "Employee",
                newName: "IsDisabled");

            migrationBuilder.AddColumn<int>(
                name: "InhabilitiesGrade",
                table: "EmployeModelView",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InhabilitiesGrade",
                table: "Employee",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InhabilitiesGrade",
                table: "EmployeModelView");

            migrationBuilder.DropColumn(
                name: "InhabilitiesGrade",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "IsDisabled",
                table: "EmployeModelView",
                newName: "Visual");

            migrationBuilder.RenameColumn(
                name: "IsDisabled",
                table: "Employee",
                newName: "Visual");

            migrationBuilder.AddColumn<bool>(
                name: "Mental",
                table: "EmployeModelView",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Motor",
                table: "EmployeModelView",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Mental",
                table: "Employee",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Motor",
                table: "Employee",
                nullable: false,
                defaultValue: false);
        }
    }
}
