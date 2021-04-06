using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[,]
                {
                    { 1, "Nelson Mandela", new DateTime(2021, 4, 6, 13, 3, 28, 568, DateTimeKind.Local).AddTicks(5165), "The greatest glory in living lies not in never falling, but in rising every time we fall." },
                    { 2, "Walt Disney", new DateTime(2021, 4, 6, 13, 3, 28, 569, DateTimeKind.Local).AddTicks(6992), "The way to get started is to quit talking and begin doing." },
                    { 3, "Eleanor Roosevelt", new DateTime(2021, 4, 6, 13, 3, 28, 569, DateTimeKind.Local).AddTicks(7013), "If life were predictable it would cease to be life, and be without flavor." },
                    { 4, "John Lennon", new DateTime(2021, 4, 6, 13, 3, 28, 569, DateTimeKind.Local).AddTicks(7015), "Life is what happens when you're busy making other plans." },
                    { 5, "Franklin D. Roosevelt", new DateTime(2021, 4, 6, 13, 3, 28, 569, DateTimeKind.Local).AddTicks(7016), "When you reach the end of your rope, tie a knot in it and hang on." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
