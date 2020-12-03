using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSocialMedia.Infra.DataAccess.Migrations
{
    public partial class added_phone_to_profile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Profiles");
        }
    }
}
