using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSharingPortal.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarSharingOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateTravelStart = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<string>(nullable: false),
                    TravelRouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSharingOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarSharingOffers_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarSharingOffers_TravelRoutes_TravelRouteId",
                        column: x => x.TravelRouteId,
                        principalTable: "TravelRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitiesTravelRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(nullable: false),
                    TravelRouteEndPointId = table.Column<int>(nullable: false),
                    TravelRouteConnectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesTravelRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitiesTravelRoutes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteConnectionId",
                        column: x => x.TravelRouteConnectionId,
                        principalTable: "TravelRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteEndPointId",
                        column: x => x.TravelRouteEndPointId,
                        principalTable: "TravelRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarSharingOffers_AuthorId",
                table: "CarSharingOffers",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarSharingOffers_TravelRouteId",
                table: "CarSharingOffers",
                column: "TravelRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTravelRoutes_CityId",
                table: "CitiesTravelRoutes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteConnectionId",
                table: "CitiesTravelRoutes",
                column: "TravelRouteConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteEndPointId",
                table: "CitiesTravelRoutes",
                column: "TravelRouteEndPointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarSharingOffers");

            migrationBuilder.DropTable(
                name: "CitiesTravelRoutes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "TravelRoutes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
