using LibraryManagement.Api.Data.Configurations;
using LibraryManagement.Api.Models.Books;
using LibraryManagement.Api.Models.Commons;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;

namespace LibraryManagement.Api.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Apply configurations using separate configuration classes
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());

            base.OnModelCreating(modelBuilder);


            // Seed initial data
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "USA" },
                new Country { CountryId = 2, CountryName = "UK" },
                new Country { CountryId = 3, CountryName = "Canada" },
                new Country { CountryId = 4, CountryName = "Australia" },
                new Country { CountryId = 5, CountryName = "Germany" }
            );

            // Seed Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Fiction", Description = "Fiction Books" },
                new Genre { GenreId = 2, GenreName = "Non-Fiction", Description = "Non-Fiction Books" },
                new Genre { GenreId = 3, GenreName = "Science Fiction", Description = "Science Fiction Books" },
                new Genre { GenreId = 4, GenreName = "Mystery", Description = "Mystery Novels" },
                new Genre { GenreId = 5, GenreName = "Romance", Description = "Romance Novels" }
            );

            // Seed Publishers
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherId = 1, PublisherName = "Penguin Random House", CountryInfoId = 1 },
                new Publisher { PublisherId = 2, PublisherName = "HarperCollins", CountryInfoId = 2 },
                new Publisher { PublisherId = 3, PublisherName = "Simon & Schuster", CountryInfoId = 3 },
                new Publisher { PublisherId = 4, PublisherName = "Random House", CountryInfoId = 1 },
                new Publisher { PublisherId = 5, PublisherName = "Macmillan Publishers", CountryInfoId = 4 }
            );


            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, FullName = "J.K. Rowling", Biography = "J.K. Rowling's Biography", CountryInfoId = 1 },
                new Author { AuthorId = 2, FullName = "Stephen King", Biography = "Stephen King's Biography", CountryInfoId = 2 },
                new Author { AuthorId = 3, FullName = "Agatha Christie", Biography = "Agatha Christie's Biography", CountryInfoId = 3 },
                new Author { AuthorId = 4, FullName = "Jane Austen", Biography = "Jane Austen's Biography", CountryInfoId = 5 },
                new Author { AuthorId = 5, FullName = "Leo Tolstoy", Biography = "Leo Tolstoy's Biography", CountryInfoId = 5 },
                new Author { AuthorId = 6, FullName = "Ernest Hemingway", Biography = "Ernest Hemingway's Biography", CountryInfoId = 1 }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Description = "The first book in the Harry Potter series",
                    ISBN = "9780590353427",
                    Language = "English",
                    Pages = 320,
                    PublicationDate = new DateTime(1997, 6, 26),
                    AuthorId = 1,
                    GenreId = 1,
                    PublisherId = 1
                },
                new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "The Shining",
                    Description = "A horror novel by Stephen King",
                    ISBN = "9780307743657",
                    Language = "English",
                    Pages = 464,
                    PublicationDate = new DateTime(1977, 1, 28),
                    AuthorId = 2,
                    GenreId = 1,
                    PublisherId = 2
                },
                new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "Murder on the Orient Express",
                    Description = "A detective novel by Agatha Christie",
                    ISBN = "9780062073495",
                    Language = "English",
                    Pages = 256,
                    PublicationDate = new DateTime(1934, 1, 1),
                    AuthorId = 3,
                    GenreId = 1,
                    PublisherId = 3
                },
                new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "Pride and Prejudice",
                    Description = "A romantic novel by Jane Austen",
                    ISBN = "9780141439518",
                    Language = "English",
                    Pages = 256,
                    PublicationDate = new DateTime(1813, 1, 28),
                    AuthorId = 4,
                    GenreId = 5,
                    PublisherId = 4
                },
                new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "War and Peace",
                    Description = "Historical novel by Leo Tolstoy",
                    ISBN = "9780143039990",
                    Language = "English",
                    Pages = 256,
                    PublicationDate = new DateTime(1869, 1, 1),
                    AuthorId = 5,
                    GenreId = 1,
                    PublisherId = 2
                },
                new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "The Old Man and the Sea",
                    Description = "Novella by Ernest Hemingway",
                    ISBN = "9780684801223",
                    Language = "English",
                    Pages = 256,
                    PublicationDate = new DateTime(1952, 9, 1),
                    AuthorId = 6,
                    GenreId = 2,
                    PublisherId = 1
                }
            );
        }
    }
}
