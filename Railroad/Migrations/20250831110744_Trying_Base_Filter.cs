using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railroad.Migrations
{
    /// <inheritdoc />
    public partial class Trying_Base_Filter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StationDistrictName",
                table: "Stations",
                newName: "DistrictName");

            migrationBuilder.RenameColumn(
                name: "StationCityName",
                table: "Stations",
                newName: "CityName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DistrictName",
                table: "Stations",
                newName: "StationDistrictName");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Stations",
                newName: "StationCityName");
        }
    }
}
