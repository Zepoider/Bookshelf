﻿// <auto-generated />
using System;
using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bookshelf.Migrations
{
    [DbContext(typeof(ContextBookshelf))]
    [Migration("20190413105448_AddBookAndAuthors")]
    partial class AddBookAndAuthors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bookshelf.Models.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("AuthorId");

                    b.ToTable("DbAuthors");

                    b.HasData(
                        new { AuthorId = new Guid("289ed170-d35c-4ed1-8418-ebfe97a8a3c3"), Name = "Martin" },
                        new { AuthorId = new Guid("1606d425-e5d9-472d-be49-79b82114d185"), Name = "Lucas" }
                    );
                });

            modelBuilder.Entity("Bookshelf.Models.BookAuthor", b =>
                {
                    b.Property<Guid>("BooksId");

                    b.Property<Guid>("AuthorId");

                    b.Property<short>("AuthorOrder");

                    b.HasKey("BooksId", "AuthorId");

                    b.ToTable("DbBookAuthor");
                });

            modelBuilder.Entity("Bookshelf.Models.Books", b =>
                {
                    b.Property<Guid>("BooksId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ActualPrice");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<decimal>("OrgPrice");

                    b.Property<string>("PromotionalText");

                    b.Property<DateTime>("PublishedOn");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("SoftDeleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("BooksId");

                    b.ToTable("DbBooks");

                    b.HasData(
                        new { BooksId = new Guid("61a140e0-ec66-49b8-bc22-fcc41c282d8f"), ActualPrice = 10m, Description = "", ImageUrl = "", OrgPrice = 0.80m, PromotionalText = "", PublishedOn = new DateTime(2019, 4, 13, 10, 54, 47, 583, DateTimeKind.Utc), Publisher = "Bukva", SoftDeleted = false, Title = "Infantry" },
                        new { BooksId = new Guid("3dd02523-f5cd-4924-8b0c-e8e762a6f17a"), ActualPrice = 10m, Description = "", ImageUrl = "", OrgPrice = 0.64m, PromotionalText = "", PublishedOn = new DateTime(2019, 4, 13, 10, 54, 47, 583, DateTimeKind.Utc), Publisher = "Lucas", SoftDeleted = false, Title = "Star Wars" }
                    );
                });

            modelBuilder.Entity("Bookshelf.Models.LineItem", b =>
                {
                    b.Property<Guid>("LineItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookNum")
                        .IsRequired();

                    b.Property<decimal>("BookPrice");

                    b.Property<Guid>("BooksId");

                    b.Property<Guid>("LineNum");

                    b.Property<Guid>("OrdersId");

                    b.HasKey("LineItemId");

                    b.ToTable("DbLineItems");
                });

            modelBuilder.Entity("Bookshelf.Models.Orders", b =>
                {
                    b.Property<Guid>("OrdersId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateOrderedUtc");

                    b.Property<DateTime>("ExpectedDeliveryDate");

                    b.HasKey("OrdersId");

                    b.ToTable("DbOrders");
                });

            modelBuilder.Entity("Bookshelf.Models.Review", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BooksId");

                    b.Property<string>("Comment");

                    b.Property<short>("StarNum");

                    b.Property<string>("VoterName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ReviewId");

                    b.ToTable("DbReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
