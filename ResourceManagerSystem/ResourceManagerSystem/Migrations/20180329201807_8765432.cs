using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _8765432 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Lot_LotID1",
                table: "Deliveries");

            migrationBuilder.DropTable(
                name: "LotDelivery");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_LotID1",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "LotID1",
                table: "Deliveries");

            migrationBuilder.AlterColumn<string>(
                name: "LotID",
                table: "DeliveryModelView",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LotID",
                table: "Deliveries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    ReppID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockID);
                    table.ForeignKey(
                        name: "FK_Stock_REPPS_ReppID",
                        column: x => x.ReppID,
                        principalTable: "REPPS",
                        principalColumn: "ReppID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_LotID",
                table: "Deliveries",
                column: "LotID");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ReppID",
                table: "Stock",
                column: "ReppID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Lot_LotID",
                table: "Deliveries",
                column: "LotID",
                principalTable: "Lot",
                principalColumn: "LotID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Lot_LotID",
                table: "Deliveries");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_LotID",
                table: "Deliveries");

            migrationBuilder.AlterColumn<int>(
                name: "LotID",
                table: "DeliveryModelView",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LotID",
                table: "Deliveries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LotID1",
                table: "Deliveries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LotDelivery",
                columns: table => new
                {
                    LotDeliveryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeliveryID = table.Column<int>(nullable: false),
                    LotID = table.Column<int>(nullable: false),
                    LotID1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotDelivery", x => x.LotDeliveryID);
                    table.ForeignKey(
                        name: "FK_LotDelivery_Deliveries_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "Deliveries",
                        principalColumn: "DeliveryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotDelivery_Lot_LotID1",
                        column: x => x.LotID1,
                        principalTable: "Lot",
                        principalColumn: "LotID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_LotID1",
                table: "Deliveries",
                column: "LotID1");

            migrationBuilder.CreateIndex(
                name: "IX_LotDelivery_DeliveryID",
                table: "LotDelivery",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_LotDelivery_LotID1",
                table: "LotDelivery",
                column: "LotID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Lot_LotID1",
                table: "Deliveries",
                column: "LotID1",
                principalTable: "Lot",
                principalColumn: "LotID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
