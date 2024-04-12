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
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Biography = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
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
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: true),
                    PublisherId = table.Column<int>(type: "int", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId");
                    table.ForeignKey(
                        name: "FK_Books_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId");
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
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
                    { 3, "Canada" },
                    { 4, "Australia" },
                    { 5, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Description", "GenreName" },
                values: new object[,]
                {
                    { 1, "Fiction Books", "Fiction" },
                    { 2, "Non-Fiction Books", "Non-Fiction" },
                    { 3, "Science Fiction Books", "Science Fiction" },
                    { 4, "Mystery Novels", "Mystery" },
                    { 5, "Romance Novels", "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Biography", "CountryInfoId", "FullName" },
                values: new object[,]
                {
                    { 1, "J.K. Rowling's Biography", 1, "J.K. Rowling" },
                    { 2, "Stephen King's Biography", 2, "Stephen King" },
                    { 3, "Agatha Christie's Biography", 3, "Agatha Christie" },
                    { 4, "Jane Austen's Biography", 5, "Jane Austen" },
                    { 5, "Leo Tolstoy's Biography", 5, "Leo Tolstoy" },
                    { 6, "Ernest Hemingway's Biography", 1, "Ernest Hemingway" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "CountryInfoId", "PublisherName" },
                values: new object[,]
                {
                    { 1, 1, "Penguin Random House" },
                    { 2, 2, "HarperCollins" },
                    { 3, 3, "Simon & Schuster" },
                    { 4, 1, "Random House" },
                    { 5, 4, "Macmillan Publishers" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AdditionalDetails", "AuthorId", "CountryId", "CoverImagePath", "Description", "GenreId", "ISBN", "Language", "Pages", "PublicationDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { new Guid("41e5f232-50f1-464e-be9e-b099cf899779"), null, 5, null, null, "Historical novel by Leo Tolstoy", 1, "9780143039990", "English", 256, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "War and Peace" },
                    { new Guid("93146ff1-19b1-42f7-99be-25c0a5888d35"), null, 3, null, null, "A detective novel by Agatha Christie", 1, "9780062073495", "English", 256, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Murder on the Orient Express" },
                    { new Guid("9c688f5b-93d2-4971-a4c3-27895be26ffe"), null, 2, null, null, "A horror novel by Stephen King", 1, "9780307743657", "English", 464, new DateTime(1977, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "The Shining" },
                    { new Guid("d281d34c-5eb4-4e89-9033-2202cc3a11b0"), null, 6, null, null, "Novella by Ernest Hemingway", 2, "9780684801223", "English", 256, new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The Old Man and the Sea" },
                    { new Guid("d73b85d1-c9ef-4a1f-aecc-ade3d96f1dcf"), null, 1, null, null, "The first book in the Harry Potter series", 1, "9780590353427", "English", 320, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("e0bc7994-2cbb-4f94-8eb1-77b1a03d5734"), null, 4, null, null, "A romantic novel by Jane Austen", 5, "9780141439518", "English", 256, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Pride and Prejudice" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CountryInfoId",
                table: "Authors",
                column: "CountryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CountryId",
                table: "Books",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

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
