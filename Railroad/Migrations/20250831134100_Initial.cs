using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Railroad.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceForKGOfCarriageWeight = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PriceForKilometer = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NuberOfPlatforms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    DiscountValue = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainRoutes_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainRouteId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Platform = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DistanceFromPreviousStation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutePoints_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutePoints_TrainRoutes_TrainRouteId",
                        column: x => x.TrainRouteId,
                        principalTable: "TrainRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainRouteId = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DepartureStationId = table.Column<int>(type: "int", nullable: false),
                    DestinationStationId = table.Column<int>(type: "int", nullable: false),
                    CarriageWeight = table.Column<double>(type: "float", nullable: false),
                    Seat = table.Column<int>(type: "int", nullable: false),
                    CarriagePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RoadPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TrainRoutes_TrainRouteId",
                        column: x => x.TrainRouteId,
                        principalTable: "TrainRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "City", "Country", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyiv", "Ukraine", "Ivan", "380931234567", "Petrenko" },
                    { 2, new DateTime(1995, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lviv", "Ukraine", "Olena", "380671112233", "Shevchenko" },
                    { 3, new DateTime(1988, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Odesa", "Ukraine", "Serhiy", "380501234567", "Koval" },
                    { 4, new DateTime(1992, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dnipro", "Ukraine", "Kateryna", "380631112233", "Bondarenko" },
                    { 5, new DateTime(1985, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kharkiv", "Ukraine", "Mykola", "380671223344", "Shevtsov" },
                    { 6, new DateTime(1998, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vinnytsia", "Ukraine", "Oksana", "380931556677", "Moroz" }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "PriceForKGOfCarriageWeight", "PriceForKilometer" },
                values: new object[,]
                {
                    { 1, 2.5m, 0.5m },
                    { 2, 3m, 0.55m },
                    { 3, 2.2m, 0.45m }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CityName", "DistrictName", "Name", "NuberOfPlatforms" },
                values: new object[,]
                {
                    { 1, "Kyiv", "Podil", "Central Station", 5 },
                    { 2, "Lviv", "Halych", "South Station", 3 },
                    { 3, "Odesa", "Primorsky", "North Station", 4 },
                    { 4, "Dnipro", "Novokodatsky", "East Station", 2 },
                    { 5, "Kharkiv", "Kholodnohirsk", "West Station", 3 },
                    { 6, "Vinnytsia", "Center", "Central Vinnytsia", 2 },
                    { 7, "Cherkasy", "Center", "Cherkasy Station", 2 },
                    { 8, "Zhytomyr", "Center", "Zhytomyr Station", 2 },
                    { 9, "Poltava", "Center", "Poltava Station", 2 }
                });

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "Id", "Name", "NumberOfSeats" },
                values: new object[,]
                {
                    { 1, "Intercity-1", 200 },
                    { 2, "Express-5", 150 },
                    { 3, "Rapid-3", 180 },
                    { 4, "Local-2", 100 },
                    { 5, "NightLine-7", 220 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DiscountValue", "Email", "PersonId", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, 10, "ivan@mail.com", 1, new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5, "olena@mail.com", 2, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 15, "serhiy@mail.com", 3, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 7, "kateryna@mail.com", 4, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 12, "mykola@mail.com", 5, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, "oksana@mail.com", 6, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TrainRoutes",
                columns: new[] { "Id", "Name", "TrainId" },
                values: new object[,]
                {
                    { 1, "Kyiv - Lviv Route", 1 },
                    { 2, "Lviv - Odesa Route", 2 },
                    { 3, "Odesa - Kharkiv Route", 3 },
                    { 4, "Dnipro - Kyiv Route", 4 },
                    { 5, "Vinnytsia - Lviv Route", 5 }
                });

            migrationBuilder.InsertData(
                table: "RoutePoints",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "DistanceFromPreviousStation", "Order", "Platform", "StationId", "TrainRouteId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 9, 15, 0, 0, DateTimeKind.Unspecified), 0.0, 1, 1, 1, 1 },
                    { 2, new DateTime(2025, 8, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 10, 10, 0, 0, DateTimeKind.Unspecified), 130.0, 2, 1, 8, 1 },
                    { 3, new DateTime(2025, 8, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 11, 10, 0, 0, DateTimeKind.Unspecified), 180.0, 3, 2, 7, 1 },
                    { 4, new DateTime(2025, 8, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 12, 10, 0, 0, DateTimeKind.Unspecified), 220.0, 4, 2, 2, 1 },
                    { 5, new DateTime(2025, 8, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 13, 15, 0, 0, DateTimeKind.Unspecified), 0.0, 1, 1, 2, 2 },
                    { 6, new DateTime(2025, 8, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 14, 10, 0, 0, DateTimeKind.Unspecified), 250.0, 2, 2, 6, 2 },
                    { 7, new DateTime(2025, 8, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 15, 10, 0, 0, DateTimeKind.Unspecified), 180.0, 3, 2, 8, 2 },
                    { 8, new DateTime(2025, 8, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 16, 10, 0, 0, DateTimeKind.Unspecified), 200.0, 4, 3, 3, 2 },
                    { 9, new DateTime(2025, 8, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 29, 8, 15, 0, 0, DateTimeKind.Unspecified), 0.0, 1, 1, 3, 3 },
                    { 10, new DateTime(2025, 8, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 29, 10, 10, 0, 0, DateTimeKind.Unspecified), 400.0, 2, 1, 4, 3 },
                    { 11, new DateTime(2025, 8, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 29, 12, 10, 0, 0, DateTimeKind.Unspecified), 320.0, 3, 2, 9, 3 },
                    { 12, new DateTime(2025, 8, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 29, 14, 10, 0, 0, DateTimeKind.Unspecified), 600.0, 4, 3, 5, 3 },
                    { 13, new DateTime(2025, 8, 30, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 30, 7, 10, 0, 0, DateTimeKind.Unspecified), 0.0, 1, 1, 4, 4 },
                    { 14, new DateTime(2025, 8, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 30, 9, 40, 0, 0, DateTimeKind.Unspecified), 300.0, 2, 2, 9, 4 },
                    { 15, new DateTime(2025, 8, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 30, 11, 10, 0, 0, DateTimeKind.Unspecified), 250.0, 3, 2, 8, 4 },
                    { 16, new DateTime(2025, 8, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 30, 13, 15, 0, 0, DateTimeKind.Unspecified), 500.0, 4, 1, 1, 4 },
                    { 17, new DateTime(2025, 8, 31, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 31, 9, 15, 0, 0, DateTimeKind.Unspecified), 0.0, 1, 1, 6, 5 },
                    { 18, new DateTime(2025, 8, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 31, 10, 10, 0, 0, DateTimeKind.Unspecified), 180.0, 2, 2, 7, 5 },
                    { 19, new DateTime(2025, 8, 31, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 31, 11, 10, 0, 0, DateTimeKind.Unspecified), 130.0, 3, 2, 8, 5 },
                    { 20, new DateTime(2025, 8, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 31, 12, 10, 0, 0, DateTimeKind.Unspecified), 400.0, 4, 3, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CarriagePrice", "CarriageWeight", "CustomerId", "DepartureStationId", "DestinationStationId", "FinalPrice", "PriceId", "PurchaseDate", "RoadPrice", "Seat", "TrainRouteId" },
                values: new object[,]
                {
                    { 1, 25m, 10.0, 1, 1, 2, 295m, 1, new DateTime(2024, 9, 12, 5, 2, 3, 0, DateTimeKind.Unspecified), 270m, 12, 1 },
                    { 2, 37.5m, 15.0, 2, 2, 3, 307.5m, 1, new DateTime(2025, 8, 28, 9, 1, 1, 0, DateTimeKind.Unspecified), 270m, 8, 2 },
                    { 3, 30m, 12.0, 3, 8, 1, 300m, 1, new DateTime(2024, 7, 28, 8, 11, 12, 0, DateTimeKind.Unspecified), 270m, 9, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PersonId",
                table: "Customers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_StationId",
                table: "RoutePoints",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_TrainRouteId",
                table: "RoutePoints",
                column: "TrainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PriceId",
                table: "Tickets",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TrainRouteId",
                table: "Tickets",
                column: "TrainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainRoutes_TrainId",
                table: "TrainRoutes",
                column: "TrainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutePoints");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "TrainRoutes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
