using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railroad.Migrations
{
    /// <inheritdoc />
    public partial class Blablabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePoints_TrainRoutes_RouteId",
                table: "RoutePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prices_PricesId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PricesId",
                table: "Tickets",
                newName: "PriceId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PricesId",
                table: "Tickets",
                newName: "IX_Tickets_PriceId");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "RoutePoints",
                newName: "TrainRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_RoutePoints_RouteId",
                table: "RoutePoints",
                newName: "IX_RoutePoints_TrainRouteId");

            migrationBuilder.AddColumn<decimal>(
                name: "CarriagePrice",
                table: "Tickets",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RoadPrice",
                table: "Tickets",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CarriagePrice", "FinalPrice", "RoadPrice" },
                values: new object[] { 25m, 295m, 270m });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CarriagePrice", "FinalPrice", "RoadPrice" },
                values: new object[] { 37.5m, 307.5m, 270m });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CarriagePrice", "FinalPrice", "RoadPrice" },
                values: new object[] { 30m, 300m, 270m });

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePoints_TrainRoutes_TrainRouteId",
                table: "RoutePoints",
                column: "TrainRouteId",
                principalTable: "TrainRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prices_PriceId",
                table: "Tickets",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePoints_TrainRoutes_TrainRouteId",
                table: "RoutePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prices_PriceId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CarriagePrice",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RoadPrice",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PriceId",
                table: "Tickets",
                newName: "PricesId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PriceId",
                table: "Tickets",
                newName: "IX_Tickets_PricesId");

            migrationBuilder.RenameColumn(
                name: "TrainRouteId",
                table: "RoutePoints",
                newName: "RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_RoutePoints_TrainRouteId",
                table: "RoutePoints",
                newName: "IX_RoutePoints_RouteId");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "FinalPrice",
                value: 300m);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinalPrice",
                value: 450m);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "FinalPrice",
                value: 450m);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePoints_TrainRoutes_RouteId",
                table: "RoutePoints",
                column: "RouteId",
                principalTable: "TrainRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prices_PricesId",
                table: "Tickets",
                column: "PricesId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
