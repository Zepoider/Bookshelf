using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Migrations
{
    public partial class AddBookAndAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DbAuthors",
                columns: new[] { "AuthorId", "Name" },
                values: new object[,]
                {
                    { new Guid("289ed170-d35c-4ed1-8418-ebfe97a8a3c3"), "Martin" },
                    { new Guid("1606d425-e5d9-472d-be49-79b82114d185"), "Lucas" }
                });

            migrationBuilder.InsertData(
                table: "DbBooks",
                columns: new[] { "BooksId", "ActualPrice", "Description", "ImageUrl", "OrgPrice", "PromotionalText", "PublishedOn", "Publisher", "SoftDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("61a140e0-ec66-49b8-bc22-fcc41c282d8f"), 10m, "", "", 0.80m, "", new DateTime(2019, 4, 13, 10, 54, 47, 583, DateTimeKind.Utc), "Bukva", false, "Infantry" },
                    { new Guid("3dd02523-f5cd-4924-8b0c-e8e762a6f17a"), 10m, "", "", 0.64m, "", new DateTime(2019, 4, 13, 10, 54, 47, 583, DateTimeKind.Utc), "Lucas", false, "Star Wars" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DbAuthors",
                keyColumn: "AuthorId",
                keyValue: new Guid("1606d425-e5d9-472d-be49-79b82114d185"));

            migrationBuilder.DeleteData(
                table: "DbAuthors",
                keyColumn: "AuthorId",
                keyValue: new Guid("289ed170-d35c-4ed1-8418-ebfe97a8a3c3"));

            migrationBuilder.DeleteData(
                table: "DbBooks",
                keyColumn: "BooksId",
                keyValue: new Guid("3dd02523-f5cd-4924-8b0c-e8e762a6f17a"));

            migrationBuilder.DeleteData(
                table: "DbBooks",
                keyColumn: "BooksId",
                keyValue: new Guid("61a140e0-ec66-49b8-bc22-fcc41c282d8f"));
        }
    }
}
