using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class farolada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CollectionsREPP_OperativeID",
                table: "CollectionsREPP");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CollectionsREPP_OperativeID_ReppID",
                table: "CollectionsREPP",
                columns: new[] { "OperativeID", "ReppID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CollectionsREPP_OperativeID_ReppID",
                table: "CollectionsREPP");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionsREPP_OperativeID",
                table: "CollectionsREPP",
                column: "OperativeID");
        }
    }
}
