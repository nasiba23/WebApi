using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InserDate",
                table: "Quotes",
                newName: "InsertDate");

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[,]
                {
                    { 1, "Nelson Mandela", new DateTime(2021, 4, 6, 11, 49, 43, 286, DateTimeKind.Local).AddTicks(3124), "The greatest glory in living lies not in never falling, but in rising every time we fall." },
                    { 2, "Walt Disney", new DateTime(2021, 4, 6, 11, 49, 43, 287, DateTimeKind.Local).AddTicks(7345), "The way to get started is to quit talking and begin doing." },
                    { 3, "Eleanor Roosevelt", new DateTime(2021, 4, 6, 11, 49, 43, 287, DateTimeKind.Local).AddTicks(7375), "If life were predictable it would cease to be life, and be without flavor." },
                    { 4, "John Lennon", new DateTime(2021, 4, 6, 11, 49, 43, 287, DateTimeKind.Local).AddTicks(7377), "Life is what happens when you're busy making other plans." },
                    { 5, "Franklin D. Roosevelt", new DateTime(2021, 4, 6, 11, 49, 43, 287, DateTimeKind.Local).AddTicks(7379), "When you reach the end of your rope, tie a knot in it and hang on." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "InsertDate",
                table: "Quotes",
                newName: "InserDate");
        }
    }
}
