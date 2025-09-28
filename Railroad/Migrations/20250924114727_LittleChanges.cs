using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railroad.Migrations
{
    /// <inheritdoc />
    public partial class LittleChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NuberOfPlatforms",
                table: "Stations",
                newName: "NumberOfPlatforms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfPlatforms",
                table: "Stations",
                newName: "NuberOfPlatforms");
        }
    }
}
