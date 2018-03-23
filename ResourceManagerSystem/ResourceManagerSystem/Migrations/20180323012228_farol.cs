using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class farol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Provider_ProviderID",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_ProviderID",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ProviderID",
                table: "Contact");

            migrationBuilder.RenameColumn(
                name: "CI",
                table: "Provider",
                newName: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_ContactID",
                table: "Provider",
                column: "ContactID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Contact_ContactID",
                table: "Provider",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Contact_ContactID",
                table: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_Provider_ContactID",
                table: "Provider");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "Provider",
                newName: "CI");

            migrationBuilder.AddColumn<int>(
                name: "ProviderID",
                table: "Contact",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ProviderID",
                table: "Contact",
                column: "ProviderID",
                unique: true,
                filter: "[ProviderID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Provider_ProviderID",
                table: "Contact",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ProviderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
