using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.v1.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class WatchedEntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePerson_AspNetUsers_AppUserId",
                table: "FavouritePerson");

            migrationBuilder.CreateTable(
                name: "WatchedMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchedMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchedMovie_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WatchedTvShow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TvShowId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchedTvShow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchedTvShow_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WatchedMovie_AppUserId",
                table: "WatchedMovie",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedTvShow_AppUserId",
                table: "WatchedTvShow",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePerson_AspNetUsers_AppUserId",
                table: "FavouritePerson",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePerson_AspNetUsers_AppUserId",
                table: "FavouritePerson");

            migrationBuilder.DropTable(
                name: "WatchedMovie");

            migrationBuilder.DropTable(
                name: "WatchedTvShow");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePerson_AspNetUsers_AppUserId",
                table: "FavouritePerson",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
