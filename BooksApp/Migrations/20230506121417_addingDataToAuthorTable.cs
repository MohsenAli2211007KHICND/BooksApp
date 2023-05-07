using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BooksApp.Migrations
{
    /// <inheritdoc />
    public partial class addingDataToAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    PublishedBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorDb_BooksDb_BookId",
                        column: x => x.BookId,
                        principalTable: "BooksDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthorDb",
                columns: new[] { "Id", "Age", "BookId", "City", "Email", "FirstName", "LastName", "PublishedBook" },
                values: new object[,]
                {
                    { 1, 22, 1, "Turbat", "mohsen@gmail.com", "Mohsen", "Ali", 45 },
                    { 2, 24, 2, "Karchi", "gul@gmail.com", "Gul", "Buledai", 20 },
                    { 3, 22, 3, "Buleda", "sameer@gmail.com", "Sameer", "Ali", 12 },
                    { 4, 22, 4, "Quetta", "meer@gmail.com", "Meer", "Ali", 21 },
                    { 5, 22, 5, "Gawadar", "javed@gmail.com", "Javed", "Ali", 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorDb_BookId",
                table: "AuthorDb",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorDb");
        }
    }
}
