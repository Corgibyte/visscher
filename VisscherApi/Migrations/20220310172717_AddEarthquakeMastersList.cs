using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisscherApi.Migrations
{
    public partial class AddEarthquakeMastersList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EarthquakesMasterList",
                columns: table => new
                {
                    WikiListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastChecked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarthquakesMasterList", x => x.WikiListId);
                    table.ForeignKey(
                        name: "FK_EarthquakesMasterList_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EarthquakesMasterList",
                columns: new[] { "WikiListId", "CategoryId", "LastChecked", "Url" },
                values: new object[] { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://en.wikipedia.org/wiki/Lists_of_earthquakes" });

            migrationBuilder.CreateIndex(
                name: "IX_EarthquakesMasterList_CategoryId",
                table: "EarthquakesMasterList",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarthquakesMasterList");
        }
    }
}
