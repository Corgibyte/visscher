using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisscherApi.Migrations
{
    public partial class ResetAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "BattlesAlphabetical",
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
                    table.PrimaryKey("PK_BattlesAlphabetical", x => x.WikiListId);
                    table.ForeignKey(
                        name: "FK_BattlesAlphabetical_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattlesByDateList",
                columns: table => new
                {
                    WikiListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattlesByDateId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastChecked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattlesByDateList", x => x.WikiListId);
                    table.ForeignKey(
                        name: "FK_BattlesByDateList_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MappableEvent",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastChecked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappableEvent", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_MappableEvent_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                column: "CategoryId",
                value: 1);

            migrationBuilder.InsertData(
                table: "BattlesAlphabetical",
                columns: new[] { "WikiListId", "CategoryId", "LastChecked", "Url" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://en.wikipedia.org/wiki/List_of_battles_(alphabetical)" });

            migrationBuilder.CreateIndex(
                name: "IX_BattlesAlphabetical_CategoryId",
                table: "BattlesAlphabetical",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BattlesByDateList_CategoryId",
                table: "BattlesByDateList",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MappableEvent_CategoryId",
                table: "MappableEvent",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattlesAlphabetical");

            migrationBuilder.DropTable(
                name: "BattlesByDateList");

            migrationBuilder.DropTable(
                name: "MappableEvent");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
