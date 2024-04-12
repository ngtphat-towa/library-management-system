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
    [DbContext(typeof(LMSDbContext))]
    [Migration("20240412055606_InitialCreate")]
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
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryInfoId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.HasIndex("CountryInfoId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorID = 1,
                            Biography = "J.K. Rowling's Biography",
                            CountryInfoId = 1,
                            FullName = "J.K. Rowling"
                        },
                        new
                        {
                            AuthorID = 2,
                            Biography = "Stephen King's Biography",
                            CountryInfoId = 2,
                            FullName = "Stephen King"
                        },
                        new
                        {
                            AuthorID = 3,
                            Biography = "Agatha Christie's Biography",
                            CountryInfoId = 3,
                            FullName = "Agatha Christie"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<string>("AdditionalDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("BookImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenreID")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PublisherID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("GenreID");

                    b.HasIndex("PublisherID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookID = 1,
                            AuthorID = 1,
                            Description = "The first book in the Harry Potter series",
                            GenreID = 1,
                            ISBN = "9780590353427",
                            PublicationDate = new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherID = 1,
                            Title = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            BookID = 2,
                            AuthorID = 2,
                            Description = "A horror novel by Stephen King",
                            GenreID = 1,
                            ISBN = "9780307743657",
                            PublicationDate = new DateTime(1977, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherID = 2,
                            Title = "The Shining"
                        },
                        new
                        {
                            BookID = 3,
                            AuthorID = 3,
                            Description = "A detective novel by Agatha Christie",
                            GenreID = 1,
                            ISBN = "9780062073495",
                            PublicationDate = new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherID = 3,
                            Title = "Murder on the Orient Express"
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Description = "Fiction Books",
                            Name = "Fiction"
                        },
                        new
                        {
                            GenreId = 2,
                            Description = "Non-Fiction Books",
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            GenreId = 3,
                            Description = "Science Fiction Books",
                            Name = "Science Fiction"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryInfoId");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryInfoId = 1,
                            Name = "Penguin Random House"
                        },
                        new
                        {
                            Id = 2,
                            CountryInfoId = 2,
                            Name = "HarperCollins"
                        },
                        new
                        {
                            Id = 3,
                            CountryInfoId = 3,
                            Name = "Simon & Schuster"
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
                        });
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Author", b =>
                {
                    b.HasOne("LibraryManagement.Api.Models.Commons.Country", "CountryInfo")
                        .WithMany()
                        .HasForeignKey("CountryInfoId");

                    b.Navigation("CountryInfo");
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Book", b =>
                {
                    b.HasOne("LibraryManagement.Api.Models.Books.Author", "BookAuthor")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("LibraryManagement.Api.Models.Books.Genre", "BookGenre")
                        .WithMany()
                        .HasForeignKey("GenreID");

                    b.HasOne("LibraryManagement.Api.Models.Books.Publisher", "BookPublisher")
                        .WithMany()
                        .HasForeignKey("PublisherID");

                    b.Navigation("BookAuthor");

                    b.Navigation("BookGenre");

                    b.Navigation("BookPublisher");
                });

            modelBuilder.Entity("LibraryManagement.Api.Models.Books.Publisher", b =>
                {
                    b.HasOne("LibraryManagement.Api.Models.Commons.Country", "CountryInfo")
                        .WithMany()
                        .HasForeignKey("CountryInfoId");

                    b.Navigation("CountryInfo");
                });
#pragma warning restore 612, 618
        }
    }
}