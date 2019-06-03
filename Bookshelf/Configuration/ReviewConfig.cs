using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Configuration
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(c => c.ReviewId);

            builder.Property(t => t.BooksId)
                .IsRequired();

            builder.Property(t => t.StarNum)
                .IsRequired();

            builder.Property(t => t.VoterName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
