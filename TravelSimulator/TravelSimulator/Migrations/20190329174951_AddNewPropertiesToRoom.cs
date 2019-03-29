using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelSimulator.Migrations
{
    public partial class AddNewPropertiesToRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCleaned",
                table: "Rooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "Rooms",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCleaned",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "Rooms");
        }
    }
}
