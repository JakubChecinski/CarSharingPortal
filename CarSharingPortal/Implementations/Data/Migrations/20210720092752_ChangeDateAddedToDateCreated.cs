using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSharingPortal.Implementations.Data.Migrations
{
    public partial class ChangeDateAddedToDateCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "CarSharingOffers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CarSharingOffers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CarSharingOffers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "CarSharingOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
