using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.v1.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class OnModelCreateMethodRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteMovie_AspNetUsers_AppUserId",
                table: "FavouriteMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePerson_AspNetUsers_AppUserId",
                table: "FavouritePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteTvShow_AspNetUsers_AppUserId",
                table: "FavouriteTvShow");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovie_AspNetUsers_AppUserId",
                table: "WatchedMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedTvShow_AspNetUsers_AppUserId",
                table: "WatchedTvShow");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteMovie_AspNetUsers_AppUserId",
                table: "FavouriteMovie",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePerson_AspNetUsers_AppUserId",
                table: "FavouritePerson",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteTvShow_AspNetUsers_AppUserId",
                table: "FavouriteTvShow",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovie_AspNetUsers_AppUserId",
                table: "WatchedMovie",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedTvShow_AspNetUsers_AppUserId",
                table: "WatchedTvShow",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteMovie_AspNetUsers_AppUserId",
                table: "FavouriteMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouritePerson_AspNetUsers_AppUserId",
                table: "FavouritePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteTvShow_AspNetUsers_AppUserId",
                table: "FavouriteTvShow");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedMovie_AspNetUsers_AppUserId",
                table: "WatchedMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedTvShow_AspNetUsers_AppUserId",
                table: "WatchedTvShow");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteMovie_AspNetUsers_AppUserId",
                table: "FavouriteMovie",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouritePerson_AspNetUsers_AppUserId",
                table: "FavouritePerson",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteTvShow_AspNetUsers_AppUserId",
                table: "FavouriteTvShow",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedMovie_AspNetUsers_AppUserId",
                table: "WatchedMovie",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedTvShow_AspNetUsers_AppUserId",
                table: "WatchedTvShow",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
