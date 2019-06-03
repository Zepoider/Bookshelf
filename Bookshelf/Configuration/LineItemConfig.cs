using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Configuration
{
    public class LineItemConfig : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(c => c.LineItemId);

            builder.Property(t => t.BooksId)
                .IsRequired();

            builder.Property(t => t.OrdersId)
                .IsRequired();

            builder.Property(t => t.BookPrice)
                .IsRequired();

            builder.Property(t => t.BookNum)
            .IsRequired();

            builder.Property(t => t.LineNum)
                .IsRequired();
        }
    }
}
