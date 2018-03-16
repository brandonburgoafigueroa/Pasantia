using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Data.Migrations
{
    public partial class DividiendoAdministrativoEnOtraClaseSinHerencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Operative_PositionID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdministrativeName",
                table: "Operative");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Operative");

            migrationBuilder.AddColumn<int>(
                name: "AdministrativeID",
                table: "Operative",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Administratives",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdministrativeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratives", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operative_AdministrativeID",
                table: "Operative",
                column: "AdministrativeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Administratives_PositionID",
                table: "Employees",
                column: "PositionID",
                principalTable: "Administratives",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operative_Administratives_AdministrativeID",
                table: "Operative",
                column: "AdministrativeID",
                principalTable: "Administratives",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Administratives_PositionID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Operative_Administratives_AdministrativeID",
                table: "Operative");

            migrationBuilder.DropTable(
                name: "Administratives");

            migrationBuilder.DropIndex(
                name: "IX_Operative_AdministrativeID",
                table: "Operative");

            migrationBuilder.DropColumn(
                name: "AdministrativeID",
                table: "Operative");

            migrationBuilder.AddColumn<string>(
                name: "AdministrativeName",
                table: "Operative",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Operative",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Operative_PositionID",
                table: "Employees",
                column: "PositionID",
                principalTable: "Operative",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
