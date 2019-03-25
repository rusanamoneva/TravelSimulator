using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelSimulator.Migrations
{
    public partial class AddNewPropertiesToVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Towns",
                newName: "TownName");

            migrationBuilder.RenameColumn(
                name: "TouristName",
                table: "Tourists",
                newName: "TouristLastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "CountryName");

            migrationBuilder.AddColumn<int>(
                name: "CancellationPeriod",
                table: "Vouchers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Tourists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TouristFirstName",
                table: "Tourists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancellationPeriod",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Tourists");

            migrationBuilder.DropColumn(
                name: "TouristFirstName",
                table: "Tourists");

            migrationBuilder.RenameColumn(
                name: "TownName",
                table: "Towns",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TouristLastName",
                table: "Tourists",
                newName: "TouristName");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Countries",
                newName: "Name");
        }
    }
}
