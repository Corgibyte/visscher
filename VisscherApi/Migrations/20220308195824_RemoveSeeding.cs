using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisscherApi.Migrations
{
    public partial class RemoveSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MappableEvent",
                keyColumn: "EventId",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MappableEvent",
                columns: new[] { "EventId", "CategoryId", "Discriminator", "LastChecked", "Latitude", "Longitude", "Name", "Url", "Year" },
                values: new object[] { 1, 1, "Battle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 0f, "Battle of Ad Decimum", "https://en.wikipedia.org/wiki/Battle_of_Ad_Decimum", 0 });
        }
    }
}
