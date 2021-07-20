using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSharingPortal.Implementations.Data.Migrations
{
    public partial class AddSeparateFieldsForAuthorEmailAndName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorEmail",
                table: "CarSharingOffers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "CarSharingOffers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorEmail",
                table: "CarSharingOffers");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "CarSharingOffers");
        }
    }
}
