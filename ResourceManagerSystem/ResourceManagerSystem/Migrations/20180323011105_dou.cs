using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class dou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionsREPP",
                table: "CollectionsREPP");

            migrationBuilder.DropIndex(
                name: "IX_CollectionsREPP_OperativeID",
                table: "CollectionsREPP");

            migrationBuilder.DropIndex(
                name: "IX_CollectionsREPP_ReppID",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionsREPP",
                table: "CollectionsREPP",
                column: "CollectionREPPID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionsREPP_OperativeID",
                table: "CollectionsREPP",
                column: "OperativeID");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionsREPP_ReppID",
                table: "CollectionsREPP",
                column: "ReppID");
        }
    }
}
