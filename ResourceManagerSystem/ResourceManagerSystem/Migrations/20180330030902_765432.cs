using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _765432 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "REPPS");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Deliveries",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Deliveries");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "REPPS",
                nullable: false,
                defaultValue: "");
        }
    }
}
