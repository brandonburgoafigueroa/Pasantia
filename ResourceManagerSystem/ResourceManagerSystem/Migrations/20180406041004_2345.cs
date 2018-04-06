using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _2345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Lot");

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "Deliveries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Deliveries");

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "Lot",
                nullable: false,
                defaultValue: 0);
        }
    }
}
