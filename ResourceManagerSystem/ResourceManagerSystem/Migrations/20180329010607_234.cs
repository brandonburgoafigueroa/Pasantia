using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResourceManagerSystem.Migrations
{
    public partial class _234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    DeliveryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ReppID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.DeliveryID);
                    table.ForeignKey(
                        name: "FK_Delivery_REPPS_ReppID",
                        column: x => x.ReppID,
                        principalTable: "REPPS",
                        principalColumn: "ReppID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryModelView",
                columns: table => new
                {
                    DeliveryModelViewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ColorName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LotID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ReppID = table.Column<int>(nullable: false),
                    SizeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryModelView", x => x.DeliveryModelViewID);
                    table.ForeignKey(
                        name: "FK_DeliveryModelView_Color_ColorName",
                        column: x => x.ColorName,
                        principalTable: "Color",
                        principalColumn: "ColorName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryModelView_REPPS_ReppID",
                        column: x => x.ReppID,
                        principalTable: "REPPS",
                        principalColumn: "ReppID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryModelView_Size_SizeName",
                        column: x => x.SizeName,
                        principalTable: "Size",
                        principalColumn: "SizeName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    LotID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProviderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.LotID);
                    table.ForeignKey(
                        name: "FK_Lot_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_LotDelivery_Delivery_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "Delivery",
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
                name: "IX_Delivery_ReppID",
                table: "Delivery",
                column: "ReppID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryModelView_ColorName",
                table: "DeliveryModelView",
                column: "ColorName");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryModelView_ReppID",
                table: "DeliveryModelView",
                column: "ReppID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryModelView_SizeName",
                table: "DeliveryModelView",
                column: "SizeName");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_ProviderID",
                table: "Lot",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_LotDelivery_DeliveryID",
                table: "LotDelivery",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_LotDelivery_LotID1",
                table: "LotDelivery",
                column: "LotID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryModelView");

            migrationBuilder.DropTable(
                name: "LotDelivery");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Lot");
        }
    }
}
