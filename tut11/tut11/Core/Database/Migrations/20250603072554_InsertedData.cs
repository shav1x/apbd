using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tut11.Core.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "IdActor", "Name", "Nickname", "Surname" },
                values: new object[,]
                {
                    { 1, "Tom", "Tommy", "Hanks" },
                    { 2, "Robert", "RDJ", "Downey Jr." }
                });

            migrationBuilder.InsertData(
                table: "AgeRatings",
                columns: new[] { "IdAgeRating", "Name" },
                values: new object[,]
                {
                    { 1, "G" },
                    { 2, "PG" },
                    { 3, "PG-13" },
                    { 4, "R" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "IdMovie", "AgeRatingId", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 1, "Toy Story", new DateTime(1995, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, "The Avengers", new DateTime(2012, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ActorMovies",
                columns: new[] { "IdActor", "IdMovie", "CharacterName" },
                values: new object[,]
                {
                    { 1, 1, "Woody" },
                    { 2, 2, "Tony Stark" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "IdActor", "IdMovie" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumns: new[] { "IdActor", "IdMovie" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AgeRatings",
                keyColumn: "IdAgeRating",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AgeRatings",
                keyColumn: "IdAgeRating",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "IdActor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "IdActor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "IdMovie",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "IdMovie",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AgeRatings",
                keyColumn: "IdAgeRating",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AgeRatings",
                keyColumn: "IdAgeRating",
                keyValue: 3);
        }
    }
}
