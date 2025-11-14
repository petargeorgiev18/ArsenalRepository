using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesData.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageUrlPropToActorEntityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Actors");
        }
    }
}
