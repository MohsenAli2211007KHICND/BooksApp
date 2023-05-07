using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BooksApp.Migrations
{
    /// <inheritdoc />
    public partial class insertingDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RealeseYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Pages = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksDb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BooksDb",
                columns: new[] { "Id", "Author", "BookTitle", "Pages", "RealeseYear" },
                values: new object[,]
                {
                    { 1, "Mohsen Ali", "Code With Mohsen Ali", 230, 2019 },
                    { 2, "Gul Buledai", "Code With Gul Buledai", 160, 2017 },
                    { 3, "Sameer Ali", "Code With Sameer Ali", 190, 2017 },
                    { 4, "Meer Ali", "Code With Meer Ali", 197, 2018 },
                    { 5, "Javed Ali", "Code With Javed Ali", 230, 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksDb");
        }
    }
}
