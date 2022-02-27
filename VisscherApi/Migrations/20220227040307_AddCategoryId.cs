using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisscherApi.Migrations
{
    public partial class AddCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MappableEvent_Categories_CategoryId",
                table: "MappableEvent");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "MappableEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "MappableEvent",
                columns: new[] { "EventId", "CategoryId", "Discriminator", "LastChecked", "Latitude", "Longitude", "Name", "Url", "Year" },
                values: new object[] { 1, 1, "Battle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 0f, "Battle of Ad Decimum", "https://en.wikipedia.org/wiki/Battle_of_Ad_Decimum", 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_MappableEvent_Categories_CategoryId",
                table: "MappableEvent",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MappableEvent_Categories_CategoryId",
                table: "MappableEvent");

            migrationBuilder.DeleteData(
                table: "MappableEvent",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "MappableEvent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MappableEvent_Categories_CategoryId",
                table: "MappableEvent",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }
    }
}
