using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scanner.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class ActivityStat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ActivityStat");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "ActivityStat",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Score",
                table: "ActivityStat",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "ActivityStat");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "ActivityStat");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ActivityStat",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
