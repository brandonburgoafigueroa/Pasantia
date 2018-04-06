using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _76543 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "Stock",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "Stock",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ColorName",
                table: "Stock",
                column: "ColorName");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_SizeName",
                table: "Stock",
                column: "SizeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Color_ColorName",
                table: "Stock",
                column: "ColorName",
                principalTable: "Color",
                principalColumn: "ColorName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Size_SizeName",
                table: "Stock",
                column: "SizeName",
                principalTable: "Size",
                principalColumn: "SizeName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Color_ColorName",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Size_SizeName",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_ColorName",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_SizeName",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "Stock");
        }
    }
}
