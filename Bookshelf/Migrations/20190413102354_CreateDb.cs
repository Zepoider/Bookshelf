using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbAuthors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAuthors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "DbBookAuthor",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    AuthorOrder = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbBookAuthor", x => new { x.BooksId, x.AuthorId });
                });

            migrationBuilder.CreateTable(
                name: "DbBooks",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Publisher = table.Column<string>(maxLength: 100, nullable: false),
                    PromotionalText = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    PublishedOn = table.Column<DateTime>(nullable: false),
                    ActualPrice = table.Column<decimal>(nullable: false),
                    OrgPrice = table.Column<decimal>(nullable: false),
                    SoftDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbBooks", x => x.BooksId);
                });

            migrationBuilder.CreateTable(
                name: "DbLineItems",
                columns: table => new
                {
                    LineItemId = table.Column<Guid>(nullable: false),
                    BooksId = table.Column<Guid>(nullable: false),
                    OrdersId = table.Column<Guid>(nullable: false),
                    LineNum = table.Column<Guid>(nullable: false),
                    BookNum = table.Column<string>(nullable: false),
                    BookPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbLineItems", x => x.LineItemId);
                });

            migrationBuilder.CreateTable(
                name: "DbOrders",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(nullable: false),
                    DateOrderedUtc = table.Column<DateTime>(nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrders", x => x.OrdersId);
                });

            migrationBuilder.CreateTable(
                name: "DbReviews",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(nullable: false),
                    BooksId = table.Column<Guid>(nullable: false),
                    VoterName = table.Column<string>(maxLength: 50, nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    StarNum = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbReviews", x => x.ReviewId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbAuthors");

            migrationBuilder.DropTable(
                name: "DbBookAuthor");

            migrationBuilder.DropTable(
                name: "DbBooks");

            migrationBuilder.DropTable(
                name: "DbLineItems");

            migrationBuilder.DropTable(
                name: "DbOrders");

            migrationBuilder.DropTable(
                name: "DbReviews");
        }
    }
}
