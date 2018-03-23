using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class separateContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Contact_CI",
                table: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_Provider_CI",
                table: "Provider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "CI",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Contact",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProviderID",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "ContactID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Provider_ProviderID",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_ProviderID",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ProviderID",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "CI",
                table: "Contact",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "CI");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_CI",
                table: "Provider",
                column: "CI",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Contact_CI",
                table: "Provider",
                column: "CI",
                principalTable: "Contact",
                principalColumn: "CI",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
