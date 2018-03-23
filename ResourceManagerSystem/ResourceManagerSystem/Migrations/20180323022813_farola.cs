using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class farola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CollectionsREPP_OperativeID_ReppID",
                table: "CollectionsREPP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionsREPP",
                table: "CollectionsREPP");

            migrationBuilder.AddColumn<int>(
                name: "CollectionREPPID",
                table: "CollectionsREPP",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CollectionsREPP_CollectionREPPID",
                table: "CollectionsREPP",
                column: "CollectionREPPID");

            migrationBuilder.AddPrimaryKey(
                name: "ID",
                table: "CollectionsREPP",
                columns: new[] { "ReppID", "OperativeID" });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionsREPP_OperativeID",
                table: "CollectionsREPP",
                column: "OperativeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CollectionsREPP_CollectionREPPID",
                table: "CollectionsREPP");

            migrationBuilder.DropPrimaryKey(
                name: "ID",
                table: "CollectionsREPP");

            migrationBuilder.DropIndex(
                name: "IX_CollectionsREPP_OperativeID",
                table: "CollectionsREPP");

            migrationBuilder.DropColumn(
                name: "CollectionREPPID",
                table: "CollectionsREPP");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CollectionsREPP_OperativeID_ReppID",
                table: "CollectionsREPP",
                columns: new[] { "OperativeID", "ReppID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionsREPP",
                table: "CollectionsREPP",
                columns: new[] { "ReppID", "OperativeID" });
        }
    }
}
