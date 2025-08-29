using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Railroad.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "City", "Country", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyiv", "Ukraine", "Ivan", "380931234567", "Petrenko" },
                    { 2, new DateTime(1995, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lviv", "Ukraine", "Olena", "380671112233", "Shevchenko" }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "PriceForKGOfCarriageWeight", "PriceForKilometer" },
                values: new object[] { 1, 2.5m, 0.5m });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Name", "NuberOfPlatforms", "StationCityName", "StationDistrictName" },
                values: new object[,]
                {
                    { 1, "Central Station", 5, "Kyiv", "Podil" },
                    { 2, "South Station", 3, "Lviv", "Halych" }
                });

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "Id", "Name", "NumberOfSeats" },
                values: new object[,]
                {
                    { 1, "Intercity-1", 200 },
                    { 2, "Express-5", 150 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DiscountValue", "Email", "PersonId", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, 10, "ivan@mail.com", 1, new DateTime(2025, 8, 28, 20, 26, 34, 155, DateTimeKind.Local).AddTicks(6972) },
                    { 2, 5, "olena@mail.com", 2, new DateTime(2025, 8, 28, 20, 26, 34, 157, DateTimeKind.Local).AddTicks(5760) }
                });

            migrationBuilder.InsertData(
                table: "TrainRoutes",
                columns: new[] { "Id", "Name", "TrainId" },
                values: new object[,]
                {
                    { 1, "Kyiv - Lviv Route", 1 },
                    { 2, "Lviv - Odesa Route", 2 }
                });

            migrationBuilder.InsertData(
                table: "RoutePoints",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "DistanceFromPreviousStation", "Order", "Platform", "RouteId", "StationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 9, 15, 0, 0, DateTimeKind.Unspecified), 0.0, 1, 1, 1, 1 },
                    { 2, new DateTime(2025, 8, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 12, 10, 0, 0, DateTimeKind.Unspecified), 540.0, 2, 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CarriageWeight", "CustomerId", "DepartureStationId", "DestinationStationId", "FinalPrice", "PricesId", "PurchaseDate", "Seat", "TrainRouteId" },
                values: new object[,]
                {
                    { 1, 10.0, 1, 1, 2, 300m, 1, new DateTime(2025, 8, 28, 20, 26, 34, 157, DateTimeKind.Local).AddTicks(9777), 12, 1 },
                    { 2, 15.0, 2, 2, 1, 450m, 1, new DateTime(2025, 8, 28, 20, 26, 34, 157, DateTimeKind.Local).AddTicks(9916), 8, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoutePoints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainRoutes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainRoutes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trains",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trains",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "PassengerId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
