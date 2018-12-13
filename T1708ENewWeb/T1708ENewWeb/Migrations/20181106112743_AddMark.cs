using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace T1708ENewWeb.Migrations
{
    public partial class AddMark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectMark",
                table: "Mark",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FirstName", "LastName", "Status", "UpdatedAt" },
                values: new object[] { "A002768", new DateTime(2018, 11, 6, 18, 27, 43, 536, DateTimeKind.Local), "xuanhung@gmail.com", "Hung", null, 1, new DateTime(2018, 11, 6, 18, 27, 43, 536, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FirstName", "LastName", "Status", "UpdatedAt" },
                values: new object[] { "A002778", new DateTime(2018, 11, 6, 18, 27, 43, 536, DateTimeKind.Local), "luyen@gmail.com", "Luyen", null, 1, new DateTime(2018, 11, 6, 18, 27, 43, 536, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FirstName", "LastName", "Status", "UpdatedAt" },
                values: new object[] { "A002769", new DateTime(2018, 11, 6, 18, 27, 43, 536, DateTimeKind.Local), "hong@gmail.com", "Hong", null, 1, new DateTime(2018, 11, 6, 18, 27, 43, 536, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Mark",
                columns: new[] { "Id", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[,]
                {
                    { 1, "A002768", 20, "Java" },
                    { 2, "A002768", 23, "C#" },
                    { 3, "A002768", 22, "PHP" },
                    { 4, "A002778", 25, "HTML" },
                    { 5, "A002778", 22, "Javascript" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mark",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mark",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mark",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mark",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Mark",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A002769");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A002768");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A002778");

            migrationBuilder.DropColumn(
                name: "SubjectMark",
                table: "Mark");
        }
    }
}
