using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyQuiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamingAndAddingTypeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Answers_Player_Game_Sessions_Player_Game_Session_Id",
                table: "Player_Answers");

            migrationBuilder.RenameColumn(
                name: "Player_Game_Session_Id",
                table: "Player_Answers",
                newName: "Player_Session_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Player_Answers_Player_Game_Session_Id",
                table: "Player_Answers",
                newName: "IX_Player_Answers_Player_Session_Id");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Lifelines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Answers_Player_Game_Sessions_Player_Session_Id",
                table: "Player_Answers",
                column: "Player_Session_Id",
                principalTable: "Player_Game_Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Answers_Player_Game_Sessions_Player_Session_Id",
                table: "Player_Answers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Lifelines");

            migrationBuilder.RenameColumn(
                name: "Player_Session_Id",
                table: "Player_Answers",
                newName: "Player_Game_Session_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Player_Answers_Player_Session_Id",
                table: "Player_Answers",
                newName: "IX_Player_Answers_Player_Game_Session_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Answers_Player_Game_Sessions_Player_Game_Session_Id",
                table: "Player_Answers",
                column: "Player_Game_Session_Id",
                principalTable: "Player_Game_Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
