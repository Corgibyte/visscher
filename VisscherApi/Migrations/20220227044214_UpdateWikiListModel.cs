using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisscherApi.Migrations
{
    public partial class UpdateWikiListModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BattlesByDateList",
                table: "BattlesByDateList");

            migrationBuilder.AlterColumn<int>(
                name: "BattlesByDateId",
                table: "BattlesByDateList",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "WikiListId",
                table: "BattlesByDateList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattlesByDateList",
                table: "BattlesByDateList",
                column: "WikiListId");

            migrationBuilder.CreateTable(
                name: "BattlesAlphabetical",
                columns: table => new
                {
                    WikiListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastChecked = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "BattlesAlphabetical",
                columns: new[] { "WikiListId", "CategoryId", "LastChecked", "Url" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://en.wikipedia.org/wiki/List_of_battles_(alphabetical)" });

            migrationBuilder.CreateIndex(
                name: "IX_BattlesByDateList_CategoryId",
                table: "BattlesByDateList",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BattlesAlphabetical_CategoryId",
                table: "BattlesAlphabetical",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattlesByDateList_Categories_CategoryId",
                table: "BattlesByDateList",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattlesByDateList_Categories_CategoryId",
                table: "BattlesByDateList");

            migrationBuilder.DropTable(
                name: "BattlesAlphabetical");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattlesByDateList",
                table: "BattlesByDateList");

            migrationBuilder.DropIndex(
                name: "IX_BattlesByDateList_CategoryId",
                table: "BattlesByDateList");

            migrationBuilder.DropColumn(
                name: "WikiListId",
                table: "BattlesByDateList");

            migrationBuilder.AlterColumn<int>(
                name: "BattlesByDateId",
                table: "BattlesByDateList",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattlesByDateList",
                table: "BattlesByDateList",
                column: "BattlesByDateId");
        }
    }
}
