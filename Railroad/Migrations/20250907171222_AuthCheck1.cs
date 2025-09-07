using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railroad.Migrations
{
    /// <inheritdoc />
    public partial class AuthCheck1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefrestToken",
                table: "Users",
                newName: "RefreshToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "Users",
                newName: "RefrestToken");
        }
    }
}
