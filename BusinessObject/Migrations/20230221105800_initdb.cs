using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email_address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    pub_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    publisher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.pub_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pub_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    advanced = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    royalty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ytd_date = table.Column<DateTime>(type: "date", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    published_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_pub_id",
                        column: x => x.pub_id,
                        principalTable: "Publishers",
                        principalColumn: "pub_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    pub_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_Publishers_pub_id",
                        column: x => x.pub_id,
                        principalTable: "Publishers",
                        principalColumn: "pub_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    author_order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    royality_percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.author_id, x.book_id });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_author_id",
                        column: x => x.author_id,
                        principalTable: "Authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "author_id", "address", "city", "email_address", "first_name", "last_name", "phone", "state", "zip" },
                values: new object[,]
                {
                    { 1, "237 Lê Văn Việt", "Hồ Chí Minh", "thanhtrung@gmai.com", "Thanh Trung", "Nguyen", "0908456789", "Hồ Chí Minh", "700000" },
                    { 2, "123 đường 1", "Ha Noi", "anhkhoa@gmail.com", "Anh Khoa", "Tran", "0908123456", "Ha Noi", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "pub_id", "city", "country", "publisher_name", "state" },
                values: new object[,]
                {
                    { 1, "London", "England", "Hoyoverse", "" },
                    { 2, "Ho Chi Minh", "Viet Nam", "Arknights", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "role_id", "role_desc" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Member" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "book_id", "advanced", "note", "price", "pub_id", "published_date", "royalty", "title", "type", "ytd_date" },
                values: new object[,]
                {
                    { 1, "", "", 300000m, 1, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Local), "Copyright of Author 1", "The life of Author 1", "Romantic", new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "", "", 300000m, 2, new DateTime(2022, 4, 27, 0, 0, 0, 0, DateTimeKind.Local), "Copyright of Author 2", "The adventure of Author 2", "Adventure", new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "email_address", "first_name", "last_name", "password", "pub_id", "role_id", "source" },
                values: new object[,]
                {
                    { 1, "member1@gmail.com", "Hao", "Nam", "1", 1, 2, "Member1SourceLink.com" },
                    { 2, "member2@gmail.com", "Lien", "Huong", "2", 2, 2, "Member2SourceLink.com" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "author_id", "book_id", "author_order", "royality_percentage" },
                values: new object[] { 1, 1, "", 60 });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "author_id", "book_id", "author_order", "royality_percentage" },
                values: new object[] { 2, 2, "", 25 });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_book_id",
                table: "BookAuthors",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_pub_id",
                table: "Books",
                column: "pub_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_pub_id",
                table: "Users",
                column: "pub_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
