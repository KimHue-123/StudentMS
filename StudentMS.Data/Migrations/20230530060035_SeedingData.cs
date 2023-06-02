using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentMS.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Dob", "Name", "PhoneNumber", "Sex" },
                values: new object[,]
                {
                    { 1, "Q1", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vo A", "00001", "Nam" },
                    { 2, "Q2", new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vo B", "00002", "Nu" },
                    { 3, "Q3", new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vo C", "00003", "Nam" },
                    { 4, "Q4", new DateTime(2001, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vo D", "00004", "Nam" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "Chemistry", "Chemistry subject" },
                    { "Physics", "Physics subject" },
                    { "Math", "Math subject" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "StudentId", "SubjectId", "Score" },
                values: new object[] { 1, "Chemistry", 8f });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "StudentId", "SubjectId", "Score" },
                values: new object[] { 1, "Physics", 7.5f });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "StudentId", "SubjectId", "Score" },
                values: new object[] { 1, "Math", 8f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { 1, "Chemistry" });

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { 1, "Math" });

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { 1, "Physics" });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "Chemistry");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "Math");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: "Physics");
        }
    }
}
