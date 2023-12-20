using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class TimestampPostgresErrorFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Task",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f01b5a99-7b59-477b-899f-efce65d57366"),
                column: "CreationDate",
                value: new DateTime(2023, 12, 19, 21, 36, 16, 691, DateTimeKind.Local).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f01b5a99-7b59-477b-899f-efce65d573a5"),
                column: "CreationDate",
                value: new DateTime(2023, 12, 19, 21, 36, 16, 691, DateTimeKind.Local).AddTicks(3260));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f01b5a99-7b59-477b-899f-efce65d57366"),
                column: "CreationDate",
                value: new DateTime(2023, 12, 19, 21, 33, 46, 163, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("f01b5a99-7b59-477b-899f-efce65d573a5"),
                column: "CreationDate",
                value: new DateTime(2023, 12, 19, 21, 33, 46, 163, DateTimeKind.Local).AddTicks(7430));
        }
    }
}
