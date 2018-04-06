using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _543 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operative_Administrative_AdministrativeID",
                table: "Operative");

            migrationBuilder.DropForeignKey(
                name: "FK_Operative_Region_RegionID",
                table: "Operative");

            migrationBuilder.DropIndex(
                name: "IX_Operative_AdministrativeID",
                table: "Operative");

            migrationBuilder.DropIndex(
                name: "IX_Operative_RegionID",
                table: "Operative");

            migrationBuilder.DropColumn(
                name: "AdministrativeID",
                table: "Operative");

            migrationBuilder.DropColumn(
                name: "RegionID",
                table: "Operative");

            migrationBuilder.AddColumn<int>(
                name: "AdministrativeID",
                table: "Contrat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionID",
                table: "Administrative",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_AdministrativeID",
                table: "Contrat",
                column: "AdministrativeID");

            migrationBuilder.CreateIndex(
                name: "IX_Administrative_RegionID",
                table: "Administrative",
                column: "RegionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrative_Region_RegionID",
                table: "Administrative",
                column: "RegionID",
                principalTable: "Region",
                principalColumn: "RegionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrat_Administrative_AdministrativeID",
                table: "Contrat",
                column: "AdministrativeID",
                principalTable: "Administrative",
                principalColumn: "AdministrativeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrative_Region_RegionID",
                table: "Administrative");

            migrationBuilder.DropForeignKey(
                name: "FK_Contrat_Administrative_AdministrativeID",
                table: "Contrat");

            migrationBuilder.DropIndex(
                name: "IX_Contrat_AdministrativeID",
                table: "Contrat");

            migrationBuilder.DropIndex(
                name: "IX_Administrative_RegionID",
                table: "Administrative");

            migrationBuilder.DropColumn(
                name: "AdministrativeID",
                table: "Contrat");

            migrationBuilder.DropColumn(
                name: "RegionID",
                table: "Administrative");

            migrationBuilder.AddColumn<int>(
                name: "AdministrativeID",
                table: "Operative",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionID",
                table: "Operative",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Operative_AdministrativeID",
                table: "Operative",
                column: "AdministrativeID");

            migrationBuilder.CreateIndex(
                name: "IX_Operative_RegionID",
                table: "Operative",
                column: "RegionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Operative_Administrative_AdministrativeID",
                table: "Operative",
                column: "AdministrativeID",
                principalTable: "Administrative",
                principalColumn: "AdministrativeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operative_Region_RegionID",
                table: "Operative",
                column: "RegionID",
                principalTable: "Region",
                principalColumn: "RegionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
