using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSharingPortal.Implementations.Data.Migrations
{
    public partial class Add_IsAuthorPassenger_To_CarSharingOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAuthorPassenger",
                table: "CarSharingOffers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuthorPassenger",
                table: "CarSharingOffers");
        }
    }
}
