using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class EnrollmentsEnEpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Administrative_AdministrativeID",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "AdministrativeID",
                table: "Employee",
                newName: "OperativeID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_AdministrativeID",
                table: "Employee",
                newName: "IX_Employee_OperativeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Operative_OperativeID",
                table: "Employee",
                column: "OperativeID",
                principalTable: "Operative",
                principalColumn: "OperativeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Operative_OperativeID",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "OperativeID",
                table: "Employee",
                newName: "AdministrativeID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_OperativeID",
                table: "Employee",
                newName: "IX_Employee_AdministrativeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Administrative_AdministrativeID",
                table: "Employee",
                column: "AdministrativeID",
                principalTable: "Administrative",
                principalColumn: "AdministrativeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
