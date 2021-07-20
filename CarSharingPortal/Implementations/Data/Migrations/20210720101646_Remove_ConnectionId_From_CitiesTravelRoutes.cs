using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSharingPortal.Implementations.Data.Migrations
{
    public partial class Remove_ConnectionId_From_CitiesTravelRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteConnectionId",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteEndPointId",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteConnectionId",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteEndPointId",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropColumn(
                name: "TravelRouteConnectionId",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropColumn(
                name: "TravelRouteEndPointId",
                table: "CitiesTravelRoutes");

            migrationBuilder.AddColumn<int>(
                name: "TravelRouteId",
                table: "CitiesTravelRoutes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TravelRouteId1",
                table: "CitiesTravelRoutes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteId",
                table: "CitiesTravelRoutes",
                column: "TravelRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteId1",
                table: "CitiesTravelRoutes",
                column: "TravelRouteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteId",
                table: "CitiesTravelRoutes",
                column: "TravelRouteId",
                principalTable: "TravelRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteId1",
                table: "CitiesTravelRoutes",
                column: "TravelRouteId1",
                principalTable: "TravelRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteId",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteId1",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteId",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteId1",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropColumn(
                name: "TravelRouteId",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropColumn(
                name: "TravelRouteId1",
                table: "CitiesTravelRoutes");

            migrationBuilder.AddColumn<int>(
                name: "TravelRouteConnectionId",
                table: "CitiesTravelRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TravelRouteEndPointId",
                table: "CitiesTravelRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteConnectionId",
                table: "CitiesTravelRoutes",
                column: "TravelRouteConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteEndPointId",
                table: "CitiesTravelRoutes",
                column: "TravelRouteEndPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteConnectionId",
                table: "CitiesTravelRoutes",
                column: "TravelRouteConnectionId",
                principalTable: "TravelRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteEndPointId",
                table: "CitiesTravelRoutes",
                column: "TravelRouteEndPointId",
                principalTable: "TravelRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
