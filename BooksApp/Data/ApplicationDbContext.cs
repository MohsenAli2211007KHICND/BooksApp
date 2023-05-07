using BooksApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> BooksDb { get; set; }
        public DbSet<Author> AuthorDb { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, BookTitle = "Code With Mohsen Ali", Author = "Mohsen Ali", RealeseYear = 2019, Pages = 230 },
                new Book { Id = 2, BookTitle = "Code With Gul Buledai", Author = "Gul Buledai", RealeseYear = 2017, Pages = 160 },
                new Book { Id = 3, BookTitle = "Code With Sameer Ali", Author = "Sameer Ali", RealeseYear = 2017, Pages = 190 },
                new Book { Id = 4, BookTitle = "Code With Meer Ali", Author = "Meer Ali", RealeseYear = 2018, Pages = 197 },
                new Book { Id = 5, BookTitle = "Code With Javed Ali", Author = "Javed Ali", RealeseYear = 2020, Pages = 230 }
                );
            modelBuilder.Entity<Author>().HasData(
                new Author 
                { 
                    Id = 1, 
                    FirstName = "Mohsen", 
                    LastName = "Ali",
                    Age = 22, 
                    Email = "mohsen@gmail.com", 
                    City = "Turbat", 
                    PublishedBook = 45, 
                    BookId = 1  
                }, 
                new Author
                {
                    Id = 2,
                    FirstName = "Gul",
                    LastName = "Buledai",
                    Age = 24,
                    Email = "gul@gmail.com",
                    City = "Karchi",
                    PublishedBook = 20,
                    BookId = 2
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Sameer",
                    LastName = "Ali",
                    Age = 22,
                    Email = "sameer@gmail.com",
                    City = "Buleda",
                    PublishedBook = 12,
                    BookId = 3
                },
                new Author
                {
                    Id = 4,
                    FirstName = "Meer",
                    LastName = "Ali",
                    Age = 22,
                    Email = "meer@gmail.com",
                    City = "Quetta",
                    PublishedBook = 21,
                    BookId = 4
                }, 
                new Author
                {
                    Id = 5,
                    FirstName = "Javed",
                    LastName = "Ali",
                    Age = 22,
                    Email = "javed@gmail.com",
                    City = "Gawadar",
                    PublishedBook = 19,
                    BookId = 5
                }
                );
        }


    }
}
