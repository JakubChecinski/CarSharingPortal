using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSharingPortal.Implementations.Data.Migrations
{
    public partial class ReworkStartAndEndCityInTravelRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteId1",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteId1",
                table: "CitiesTravelRoutes");

            migrationBuilder.DropColumn(
                name: "TravelRouteId1",
                table: "CitiesTravelRoutes");

            migrationBuilder.AddColumn<int>(
                name: "EndId",
                table: "TravelRoutes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartId",
                table: "TravelRoutes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TravelRoutes_EndId",
                table: "TravelRoutes",
                column: "EndId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelRoutes_StartId",
                table: "TravelRoutes",
                column: "StartId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRoutes_Cities_EndId",
                table: "TravelRoutes",
                column: "EndId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRoutes_Cities_StartId",
                table: "TravelRoutes",
                column: "StartId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelRoutes_Cities_EndId",
                table: "TravelRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelRoutes_Cities_StartId",
                table: "TravelRoutes");

            migrationBuilder.DropIndex(
                name: "IX_TravelRoutes_EndId",
                table: "TravelRoutes");

            migrationBuilder.DropIndex(
                name: "IX_TravelRoutes_StartId",
                table: "TravelRoutes");

            migrationBuilder.DropColumn(
                name: "EndId",
                table: "TravelRoutes");

            migrationBuilder.DropColumn(
                name: "StartId",
                table: "TravelRoutes");

            migrationBuilder.AddColumn<int>(
                name: "TravelRouteId1",
                table: "CitiesTravelRoutes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTravelRoutes_TravelRouteId1",
                table: "CitiesTravelRoutes",
                column: "TravelRouteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesTravelRoutes_TravelRoutes_TravelRouteId1",
                table: "CitiesTravelRoutes",
                column: "TravelRouteId1",
                principalTable: "TravelRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
