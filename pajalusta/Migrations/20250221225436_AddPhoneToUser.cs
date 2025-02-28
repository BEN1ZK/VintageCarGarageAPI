using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VintageCarGarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the Phone column to the Users table
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the Phone column from the Users table
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");
        }
    }
}