using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luxor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeparatePropsForFirstAndLastNameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Guests",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Guests",
                newName: "Name");
        }
    }
}
