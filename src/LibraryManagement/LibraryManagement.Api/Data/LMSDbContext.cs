using LibraryManagement.Api.Models.Books;
using LibraryManagement.Api.Models.Commons;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;

namespace LibraryManagement.Api.Data
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "USA" },
                new Country { CountryId = 2, CountryName = "UK" },
                new Country { CountryId = 3, CountryName = "Canada" }
            );

            // Seed Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "Fiction", Description = "Fiction Books" },
                new Genre { GenreId = 2, Name = "Non-Fiction", Description = "Non-Fiction Books" },
                new Genre { GenreId = 3, Name = "Science Fiction", Description = "Science Fiction Books" }
            );

            // Seed Publishers
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Penguin Random House", CountryInfoId = 1 },
                new Publisher { Id = 2, Name = "HarperCollins", CountryInfoId = 2 },
                new Publisher { Id = 3, Name = "Simon & Schuster", CountryInfoId = 3 }
            );

            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorID = 1, FullName = "J.K. Rowling", Biography = "J.K. Rowling's Biography", CountryInfoId= 1 },
                new Author { AuthorID = 2, FullName = "Stephen King", Biography = "Stephen King's Biography", CountryInfoId = 2 },
                new Author { AuthorID = 3, FullName = "Agatha Christie", Biography = "Agatha Christie's Biography", CountryInfoId = 3 }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookID = 1,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Description = "The first book in the Harry Potter series",
                    ISBN = "9780590353427",
                    PublicationDate = new DateTime(1997, 6, 26),
                    AuthorID = 1,
                    GenreID = 1,
                    PublisherID = 1
                },
                new Book
                {
                    BookID = 2,
                    Title = "The Shining",
                    Description = "A horror novel by Stephen King",
                    ISBN = "9780307743657",
                    PublicationDate = new DateTime(1977, 1, 28),
                    AuthorID = 2,
                    GenreID = 1,
                    PublisherID = 2
                },
                new Book
                {
                    BookID = 3,
                    Title = "Murder on the Orient Express",
                    Description = "A detective novel by Agatha Christie",
                    ISBN = "9780062073495",
                    PublicationDate = new DateTime(1934, 1, 1),
                    AuthorID = 3,
                    GenreID = 1,
                    PublisherID = 3
                }
            );
        }
    }
}
