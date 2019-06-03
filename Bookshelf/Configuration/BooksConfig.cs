using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Configuration
{
    public class BooksConfig : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasKey(c => c.BooksId);

            builder.Property(t => t.Description)
                .IsRequired();

            builder.Property(t => t.ImageUrl)
                .IsRequired();

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Publisher)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(t => t.ActualPrice)
                .IsRequired();
        }
    }
}
