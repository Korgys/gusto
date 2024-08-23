using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gusto.Migrations
{
    /// <inheritdoc />
    public partial class AddShopConnectionInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Shops",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Shops",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shops");
        }
    }
}
