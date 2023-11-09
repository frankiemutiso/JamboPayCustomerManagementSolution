using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDateDeletedColumnToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "date_deleted",
                table: "customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "date_deleted",
                table: "businesses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "date_deleted",
                table: "business_locations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "date_deleted",
                table: "business_categories",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_deleted",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "date_deleted",
                table: "businesses");

            migrationBuilder.DropColumn(
                name: "date_deleted",
                table: "business_locations");

            migrationBuilder.DropColumn(
                name: "date_deleted",
                table: "business_categories");
        }
    }
}
