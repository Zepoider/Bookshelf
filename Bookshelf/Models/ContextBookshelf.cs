using Bookshelf.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Models;

namespace Bookshelf.Models
{
    public class ContextBookshelf : DbContext
    {
        public ContextBookshelf(DbContextOptions<ContextBookshelf> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<Books> DbBooks { get; set; }
        public DbSet<Author> DbAuthors { get; set; }
        public DbSet<BookAuthor> DbBookAuthor { get; set; }
        public DbSet<LineItem> DbLineItems { get; set; }
        public DbSet<Orders> DbOrders { get; set; }
        public DbSet<Review> DbReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(nk => new { nk.BooksId, nk.AuthorId });
            modelBuilder.ApplyConfiguration(new BooksConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new LineItemConfig());
            modelBuilder.ApplyConfiguration(new OrdersConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());

            modelBuilder.Entity<Books>().HasData(new Books
            {
                BooksId = Guid.NewGuid(),
                Title = "Infantry",
                Description = "",
                Publisher = "Bukva",
                PromotionalText = "",
                ImageUrl = "",
                PublishedOn = DateTime.UtcNow,
                ActualPrice = 10,
                OrgPrice = 10 * 0.8M,
                SoftDeleted = false
            }, new Books
            {
                BooksId = Guid.NewGuid(),
                Title = "Star Wars",
                Description = "",
                Publisher = "Lucas",
                PromotionalText = "",
                ImageUrl = "",
                PublishedOn = DateTime.UtcNow,
                ActualPrice = 10,
                OrgPrice = 8 * 0.8M,
                SoftDeleted = false
            }
    );
            modelBuilder.Entity<Author>().HasData(new Author
            {
                AuthorId = Guid.NewGuid(),
                Name = "Martin"
            }, new Author
            {
                AuthorId = Guid.NewGuid(),
                Name = "Lucas"
            }
            );
        }

    }
}
