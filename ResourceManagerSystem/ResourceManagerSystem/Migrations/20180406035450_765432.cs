using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _765432 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "Lot",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdministrativeID",
                table: "EmployeModelView",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeModelView_AdministrativeID",
                table: "EmployeModelView",
                column: "AdministrativeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeModelView_Administrative_AdministrativeID",
                table: "EmployeModelView",
                column: "AdministrativeID",
                principalTable: "Administrative",
                principalColumn: "AdministrativeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeModelView_Administrative_AdministrativeID",
                table: "EmployeModelView");

            migrationBuilder.DropIndex(
                name: "IX_EmployeModelView_AdministrativeID",
                table: "EmployeModelView");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Lot");

            migrationBuilder.DropColumn(
                name: "AdministrativeID",
                table: "EmployeModelView");
        }
    }
}
