using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Biography = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                    table.ForeignKey(
                        name: "FK_Authors_Countries_CountryInfoId",
                        column: x => x.CountryInfoId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                    table.ForeignKey(
                        name: "FK_Publishers_Countries_CountryInfoId",
                        column: x => x.CountryInfoId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorID = table.Column<int>(type: "int", nullable: true),
                    GenreID = table.Column<int>(type: "int", nullable: true),
                    PublisherID = table.Column<int>(type: "int", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID");
                    table.ForeignKey(
                        name: "FK_Books_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreId");
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "USA" },
                    { 2, "UK" },
                    { 3, "Canada" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Description", "GenreName" },
                values: new object[,]
                {
                    { 1, "Fiction Books", "Fiction" },
                    { 2, "Non-Fiction Books", "Non-Fiction" },
                    { 3, "Science Fiction Books", "Science Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorID", "Biography", "CountryInfoId", "FullName" },
                values: new object[,]
                {
                    { 1, "J.K. Rowling's Biography", 1, "J.K. Rowling" },
                    { 2, "Stephen King's Biography", 2, "Stephen King" },
                    { 3, "Agatha Christie's Biography", 3, "Agatha Christie" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "CountryInfoId", "PublisherName" },
                values: new object[,]
                {
                    { 1, 1, "Penguin Random House" },
                    { 2, 2, "HarperCollins" },
                    { 3, 3, "Simon & Schuster" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "AdditionalDetails", "AuthorID", "BookImagePath", "CountryId", "Description", "GenreID", "ISBN", "PublicationDate", "PublisherID", "Title" },
                values: new object[,]
                {
                    { 1, null, 1, null, null, "The first book in the Harry Potter series", 1, "9780590353427", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Harry Potter and the Sorcerer's Stone" },
                    { 2, null, 2, null, null, "A horror novel by Stephen King", 1, "9780307743657", new DateTime(1977, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "The Shining" },
                    { 3, null, 3, null, null, "A detective novel by Agatha Christie", 1, "9780062073495", new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Murder on the Orient Express" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CountryInfoId",
                table: "Authors",
                column: "CountryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CountryId",
                table: "Books",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreID",
                table: "Books",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherID",
                table: "Books",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_CountryInfoId",
                table: "Publishers",
                column: "CountryInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
