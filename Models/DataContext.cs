using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Day_2.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        //private const string connectionString = "data source=DESKTOP-DT75BB7;Database=Book;Integrated Security=SSPI;persist security info=True; ";
        private const string connectionString = "data source=DESKTOP-DT75BB7;Database=Book;Integrated Security=SSPI;persist security info=True; ";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(c => c.BookID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Author>().Property(c => c.AuthorID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>().Property(c => c.ClientID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Authors);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Books)
                .WithOne(c => c.Client);

            
            modelBuilder.Entity<Author>().HasData(new Author
            {
                AuthorID = 1,
                AuthorName = "author 1",
            });
            modelBuilder.Entity<Client>().HasData(new Client
            {
                ClientID = 1,
                ClientName = "client 1",
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookID = 1,
                BookName = "book 1",
                ClientID = 1,
            });


        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        //public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}