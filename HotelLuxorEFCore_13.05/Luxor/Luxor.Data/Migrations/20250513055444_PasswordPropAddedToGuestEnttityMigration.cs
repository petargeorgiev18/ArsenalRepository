using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luxor.Data.Migrations
{
    /// <inheritdoc />
    public partial class PasswordPropAddedToGuestEnttityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Guests");
        }
    }
}
