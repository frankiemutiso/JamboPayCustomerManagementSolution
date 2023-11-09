using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterShopNumberType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "shop_number",
                table: "business_locations",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "shop_number",
                table: "business_locations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
