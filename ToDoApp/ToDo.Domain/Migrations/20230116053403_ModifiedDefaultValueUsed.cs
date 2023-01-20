using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedDefaultValueUsed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATE('now')",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 1, 16, 5, 23, 12, 977, DateTimeKind.Utc).AddTicks(329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATE('now')",
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 1, 16, 5, 23, 12, 977, DateTimeKind.Utc).AddTicks(51));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 16, 5, 23, 12, 977, DateTimeKind.Utc).AddTicks(329),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "DATE('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 16, 5, 23, 12, 977, DateTimeKind.Utc).AddTicks(51),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "DATE('now')");
        }
    }
}
