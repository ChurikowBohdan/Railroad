using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railroad.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialDataAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "PurchaseDate",
                value: new DateTime(2024, 9, 12, 5, 2, 3, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "PurchaseDate",
                value: new DateTime(2025, 8, 28, 9, 1, 1, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2025, 8, 28, 20, 26, 34, 155, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2025, 8, 28, 20, 26, 34, 157, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "PurchaseDate",
                value: new DateTime(2025, 8, 28, 20, 26, 34, 157, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "PurchaseDate",
                value: new DateTime(2025, 8, 28, 20, 26, 34, 157, DateTimeKind.Local).AddTicks(9916));
        }
    }
}
