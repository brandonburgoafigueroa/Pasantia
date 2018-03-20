using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class color : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REPPS_Color_ColorName1",
                table: "REPPS");

            migrationBuilder.DropForeignKey(
                name: "FK_REPPS_Size_SizeName1",
                table: "REPPS");

            migrationBuilder.DropIndex(
                name: "IX_REPPS_ColorName1",
                table: "REPPS");

            migrationBuilder.DropIndex(
                name: "IX_REPPS_SizeName1",
                table: "REPPS");

            migrationBuilder.DropColumn(
                name: "ColorName1",
                table: "REPPS");

            migrationBuilder.DropColumn(
                name: "SizeName1",
                table: "REPPS");

            migrationBuilder.AlterColumn<string>(
                name: "SizeName",
                table: "REPPS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ColorName",
                table: "REPPS",
                nullable: true,
                oldClrType: typeof(int));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "SizeName",
                table: "REPPS",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorName",
                table: "REPPS",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorName1",
                table: "REPPS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName1",
                table: "REPPS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_REPPS_ColorName1",
                table: "REPPS",
                column: "ColorName1");

            migrationBuilder.CreateIndex(
                name: "IX_REPPS_SizeName1",
                table: "REPPS",
                column: "SizeName1");

            migrationBuilder.AddForeignKey(
                name: "FK_REPPS_Color_ColorName1",
                table: "REPPS",
                column: "ColorName1",
                principalTable: "Color",
                principalColumn: "ColorName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_REPPS_Size_SizeName1",
                table: "REPPS",
                column: "SizeName1",
                principalTable: "Size",
                principalColumn: "SizeName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
