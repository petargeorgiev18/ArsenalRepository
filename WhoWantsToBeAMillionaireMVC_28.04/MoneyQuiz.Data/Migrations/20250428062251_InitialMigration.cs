using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyQuiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game_Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Final_Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player_Game_Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player_Id = table.Column<int>(type: "int", nullable: false),
                    Session_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Game_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Game_Sessions_Game_Sessions_Session_Id",
                        column: x => x.Session_Id,
                        principalTable: "Game_Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Game_Sessions_Players_Player_Id",
                        column: x => x.Player_Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Correct = table.Column<bool>(type: "bit", nullable: false),
                    Question_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_Question_Id",
                        column: x => x.Question_Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lifelines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player_Game_Session_Id = table.Column<int>(type: "int", nullable: false),
                    Used_On_Question_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifelines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lifelines_Player_Game_Sessions_Player_Game_Session_Id",
                        column: x => x.Player_Game_Session_Id,
                        principalTable: "Player_Game_Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lifelines_Questions_Used_On_Question_Id",
                        column: x => x.Used_On_Question_Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player_Game_Session_Id = table.Column<int>(type: "int", nullable: false),
                    Answer_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Correct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Answers_Answers_Answer_Id",
                        column: x => x.Answer_Id,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Answers_Player_Game_Sessions_Player_Game_Session_Id",
                        column: x => x.Player_Game_Session_Id,
                        principalTable: "Player_Game_Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Question_Id",
                table: "Answers",
                column: "Question_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lifelines_Player_Game_Session_Id",
                table: "Lifelines",
                column: "Player_Game_Session_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lifelines_Used_On_Question_Id",
                table: "Lifelines",
                column: "Used_On_Question_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Answers_Answer_Id",
                table: "Player_Answers",
                column: "Answer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Answers_Player_Game_Session_Id",
                table: "Player_Answers",
                column: "Player_Game_Session_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Game_Sessions_Player_Id",
                table: "Player_Game_Sessions",
                column: "Player_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Game_Sessions_Session_Id",
                table: "Player_Game_Sessions",
                column: "Session_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lifelines");

            migrationBuilder.DropTable(
                name: "Player_Answers");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Player_Game_Sessions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Game_Sessions");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
