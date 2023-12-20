using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class TaskAndCategorySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Difficulty", "Name" },
                values: new object[,]
                {
                    { new Guid("7555a122-8f47-42bf-a9ee-6a6a38ca99f8"), null, 20, "Pendient Categories" },
                    { new Guid("ab74fad2-280c-438f-8341-afc117539c09"), null, 50, "Personal Categories" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("f01b5a99-7b59-477b-899f-efce65d57366"), new Guid("ab74fad2-280c-438f-8341-afc117539c09"), new DateTime(2023, 12, 19, 21, 33, 46, 163, DateTimeKind.Local).AddTicks(7390), null, 1, "Pay taxes" },
                    { new Guid("f01b5a99-7b59-477b-899f-efce65d573a5"), new Guid("7555a122-8f47-42bf-a9ee-6a6a38ca99f8"), new DateTime(2023, 12, 19, 21, 33, 46, 163, DateTimeKind.Local).AddTicks(7430), null, 0, "Do Excercise" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f01b5a99-7b59-477b-899f-efce65d57366"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f01b5a99-7b59-477b-899f-efce65d573a5"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("7555a122-8f47-42bf-a9ee-6a6a38ca99f8"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("ab74fad2-280c-438f-8341-afc117539c09"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
