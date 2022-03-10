using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisscherApi.Migrations
{
    public partial class AddEarthquakeSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: 2);

            migrationBuilder.InsertData(
                table: "MappableEvent",
                columns: new[] { "EventId", "CategoryId", "Discriminator", "LastChecked", "Latitude", "Longitude", "Name", "Url", "Year" },
                values: new object[] { 5001, 2, "Earthquake", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 0f, "Not parsed", "https://en.wikipedia.org/wiki/2000_Enggano_earthquake", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MappableEvent",
                keyColumn: "EventId",
                keyValue: 5001);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);
        }
    }
}
