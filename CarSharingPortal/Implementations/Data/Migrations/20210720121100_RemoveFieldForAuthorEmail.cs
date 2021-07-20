using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSharingPortal.Implementations.Data.Migrations
{
    public partial class RemoveFieldForAuthorEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorEmail",
                table: "CarSharingOffers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorEmail",
                table: "CarSharingOffers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
