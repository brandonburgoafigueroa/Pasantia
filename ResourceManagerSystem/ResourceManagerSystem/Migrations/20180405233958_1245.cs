using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _1245 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REPPS_Color_ColorName",
                table: "REPPS");

            migrationBuilder.DropForeignKey(
                name: "FK_REPPS_Size_SizeName",
                table: "REPPS");

            migrationBuilder.DropIndex(
                name: "IX_REPPS_ColorName",
                table: "REPPS");

            migrationBuilder.DropIndex(
                name: "IX_REPPS_SizeName",
                table: "REPPS");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "REPPS");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "REPPS");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "REPPS",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "REPPS");

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "REPPS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "REPPS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_REPPS_ColorName",
                table: "REPPS",
                column: "ColorName");

            migrationBuilder.CreateIndex(
                name: "IX_REPPS_SizeName",
                table: "REPPS",
                column: "SizeName");

            migrationBuilder.AddForeignKey(
                name: "FK_REPPS_Color_ColorName",
                table: "REPPS",
                column: "ColorName",
                principalTable: "Color",
                principalColumn: "ColorName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_REPPS_Size_SizeName",
                table: "REPPS",
                column: "SizeName",
                principalTable: "Size",
                principalColumn: "SizeName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
