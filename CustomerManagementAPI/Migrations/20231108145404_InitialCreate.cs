using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CustomerManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "business_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    date_created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "business_locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    county = table.Column<string>(type: "text", nullable: false),
                    subcounty = table.Column<string>(type: "text", nullable: false),
                    ward = table.Column<string>(type: "text", nullable: false),
                    building_name = table.Column<string>(type: "text", nullable: false),
                    floor = table.Column<int>(type: "integer", nullable: false),
                    shop_number = table.Column<int>(type: "integer", nullable: false),
                    date_created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    nationality = table.Column<string>(type: "text", nullable: false),
                    date_created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "businesses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false),
                    owner_id = table.Column<int>(type: "integer", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businesses", x => x.id);
                    table.ForeignKey(
                        name: "FK_businesses_business_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "business_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_businesses_business_locations_location_id",
                        column: x => x.location_id,
                        principalTable: "business_locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_businesses_customers_owner_id",
                        column: x => x.owner_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_businesses_category_id",
                table: "businesses",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_businesses_location_id",
                table: "businesses",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_businesses_owner_id",
                table: "businesses",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "businesses");

            migrationBuilder.DropTable(
                name: "business_categories");

            migrationBuilder.DropTable(
                name: "business_locations");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
