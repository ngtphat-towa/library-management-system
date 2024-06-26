﻿// <auto-generated />
using System;
using LibraryManagement.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagement.Api.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20240412165342_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("CountryInfoId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.HasIndex("CountryInfoId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            Biography = "J.K. Rowling's Biography",
                            CountryInfoId = 1,
                            FullName = "J.K. Rowling"
                        },
                        new
                        {
                            AuthorId = 2,
                            Biography = "Stephen King's Biography",
                            CountryInfoId = 2,
                            FullName = "Stephen King"
                        },
                        new
                        {
                            AuthorId = 3,
                            Biography = "Agatha Christie's Biography",
                            CountryInfoId = 3,
                            FullName = "Agatha Christie"
                        },
                        new
                        {
                            AuthorId = 4,
                            Biography = "Jane Austen's Biography",
                            CountryInfoId = 5,
                            FullName = "Jane Austen"
                        },
                        new
                        {
                            AuthorId = 5,
                            Biography = "Leo Tolstoy's Biography",
                            CountryInfoId = 5,
                            FullName = "Leo Tolstoy"
                        },
                        new
                        {
                            AuthorId = 6,
                            Biography = "Ernest Hemingway's Biography",
                            CountryInfoId = 1,
                            FullName = "Ernest Hemingway"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CoverImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CountryId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = new Guid("d73b85d1-c9ef-4a1f-aecc-ade3d96f1dcf"),
                            AuthorId = 1,
                            Description = "The first book in the Harry Potter series",
                            GenreId = 1,
                            ISBN = "9780590353427",
                            Language = "English",
                            Pages = 320,
                            PublicationDate = new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 1,
                            Title = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            BookId = new Guid("9c688f5b-93d2-4971-a4c3-27895be26ffe"),
                            AuthorId = 2,
                            Description = "A horror novel by Stephen King",
                            GenreId = 1,
                            ISBN = "9780307743657",
                            Language = "English",
                            Pages = 464,
                            PublicationDate = new DateTime(1977, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 2,
                            Title = "The Shining"
                        },
                        new
                        {
                            BookId = new Guid("93146ff1-19b1-42f7-99be-25c0a5888d35"),
                            AuthorId = 3,
                            Description = "A detective novel by Agatha Christie",
                            GenreId = 1,
                            ISBN = "9780062073495",
                            Language = "English",
                            Pages = 256,
                            PublicationDate = new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 3,
                            Title = "Murder on the Orient Express"
                        },
                        new
                        {
                            BookId = new Guid("e0bc7994-2cbb-4f94-8eb1-77b1a03d5734"),
                            AuthorId = 4,
                            Description = "A romantic novel by Jane Austen",
                            GenreId = 5,
                            ISBN = "9780141439518",
                            Language = "English",
                            Pages = 256,
                            PublicationDate = new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 4,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            BookId = new Guid("41e5f232-50f1-464e-be9e-b099cf899779"),
                            AuthorId = 5,
                            Description = "Historical novel by Leo Tolstoy",
                            GenreId = 1,
                            ISBN = "9780143039990",
                            Language = "English",
                            Pages = 256,
                            PublicationDate = new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 2,
                            Title = "War and Peace"
                        },
                        new
                        {
                            BookId = new Guid("d281d34c-5eb4-4e89-9033-2202cc3a11b0"),
                            AuthorId = 6,
                            Description = "Novella by Ernest Hemingway",
                            GenreId = 2,
                            ISBN = "9780684801223",
                            Language = "English",
                            Pages = 256,
                            PublicationDate = new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 1,
                            Title = "The Old Man and the Sea"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Description = "Fiction Books",
                            GenreName = "Fiction"
                        },
                        new
                        {
                            GenreId = 2,
                            Description = "Non-Fiction Books",
                            GenreName = "Non-Fiction"
                        },
                        new
                        {
                            GenreId = 3,
                            Description = "Science Fiction Books",
                            GenreName = "Science Fiction"
                        },
                        new
                        {
                            GenreId = 4,
                            Description = "Mystery Novels",
                            GenreName = "Mystery"
                        },
                        new
                        {
                            GenreId = 5,
                            Description = "Romance Novels",
                            GenreName = "Romance"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"));

                    b.Property<int?>("CountryInfoId")
                        .HasColumnType("int");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherId");

                    b.HasIndex("CountryInfoId");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            CountryInfoId = 1,
                            PublisherName = "Penguin Random House"
                        },
                        new
                        {
                            PublisherId = 2,
                            CountryInfoId = 2,
                            PublisherName = "HarperCollins"
                        },
                        new
                        {
                            PublisherId = 3,
                            CountryInfoId = 3,
                            PublisherName = "Simon & Schuster"
                        },
                        new
                        {
                            PublisherId = 4,
                            CountryInfoId = 1,
                            PublisherName = "Random House"
                        },
                        new
                        {
                            PublisherId = 5,
                            CountryInfoId = 4,
                            PublisherName = "Macmillan Publishers"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Commons.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "USA"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "UK"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Canada"
                        },
                        new
                        {
                            CountryId = 4,
                            CountryName = "Australia"
                        },
                        new
                        {
                            CountryId = 5,
                            CountryName = "Germany"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Author", b =>
                {
                    b.HasOne("LibraryManagement.Api.Models.Commons.Country", "CountryInfo")
                        .WithMany("Authors")
                        .HasForeignKey("CountryInfoId");

                    b.Navigation("CountryInfo");
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Book", b =>
                {
                    b.HasOne("LibraryManagement.Api.Models.Books.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("LibraryManagement.Api.Models.Commons.Country", null)
                        .WithMany("Books")
                        .HasForeignKey("CountryId");

                    b.HasOne("LibraryManagement.Api.Models.Books.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("LibraryManagement.Api.Models.Books.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");

                    b.Navigation("Author");

                    b.Navigation("Genre");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Publisher", b =>
                {
                    b.HasOne("LibraryManagement.Api.Models.Commons.Country", "CountryInfo")
                        .WithMany("Publishers")
                        .HasForeignKey("CountryInfoId");

                    b.Navigation("CountryInfo");
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Commons.Country", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Books");

                    b.Navigation("Publishers");
                });
#pragma warning restore 612, 618
        }
    }
}
