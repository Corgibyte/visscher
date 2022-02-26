using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisscherApi.Migrations
{
    public partial class ChangeDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "MappableEvent");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "MappableEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "MappableEvent");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MappableEvent",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
