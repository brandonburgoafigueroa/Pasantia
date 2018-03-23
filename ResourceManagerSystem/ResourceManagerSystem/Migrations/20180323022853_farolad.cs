using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class farolad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CollectionsREPP_CollectionREPPID",
                table: "CollectionsREPP");

            migrationBuilder.DropColumn(
                name: "CollectionREPPID",
                table: "CollectionsREPP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionREPPID",
                table: "CollectionsREPP",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CollectionsREPP_CollectionREPPID",
                table: "CollectionsREPP",
                column: "CollectionREPPID");
        }
    }
}
