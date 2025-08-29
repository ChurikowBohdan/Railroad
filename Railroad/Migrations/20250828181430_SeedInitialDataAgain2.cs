using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railroad.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialDataAgain2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CarriageWeight", "CustomerId", "DepartureStationId", "DestinationStationId", "FinalPrice", "PricesId", "PurchaseDate", "Seat", "TrainRouteId" },
                values: new object[] { 3, 12.0, 2, 2, 1, 450m, 1, new DateTime(2024, 7, 28, 8, 11, 12, 0, DateTimeKind.Unspecified), 9, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
