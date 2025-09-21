using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetHunterData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "lesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cellphone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Placement = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id_lesson = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topic_lesson_id_lesson",
                        column: x => x.id_lesson,
                        principalTable: "lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id_topic = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    question_number = table.Column<int>(type: "int", nullable: false),
                    Statement = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_question_topic_id_topic",
                        column: x => x.id_topic,
                        principalTable: "topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "alternative",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id_question = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Text = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correct = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QuestionId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alternative", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alternative_question_QuestionId1",
                        column: x => x.QuestionId1,
                        principalTable: "question",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_alternative_question_id_question",
                        column: x => x.id_question,
                        principalTable: "question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_progress_topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id_user = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id_topic = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id_question = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Completed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_progress_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_progress_topic_question_id_question",
                        column: x => x.id_question,
                        principalTable: "question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_progress_topic_topic_id_topic",
                        column: x => x.id_topic,
                        principalTable: "topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_progress_topic_users_id_user",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_answer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id_user = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id_question = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    id_alternative = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Correct = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_answer_alternative_id_alternative",
                        column: x => x.id_alternative,
                        principalTable: "alternative",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_answer_question_id_question",
                        column: x => x.id_question,
                        principalTable: "question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_answer_users_id_user",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_alternative_id_question",
                table: "alternative",
                column: "id_question");

            migrationBuilder.CreateIndex(
                name: "IX_alternative_QuestionId1",
                table: "alternative",
                column: "QuestionId1");

            migrationBuilder.CreateIndex(
                name: "IX_question_id_topic",
                table: "question",
                column: "id_topic");

            migrationBuilder.CreateIndex(
                name: "IX_topic_id_lesson",
                table: "topic",
                column: "id_lesson");

            migrationBuilder.CreateIndex(
                name: "IX_user_answer_id_alternative",
                table: "user_answer",
                column: "id_alternative");

            migrationBuilder.CreateIndex(
                name: "IX_user_answer_id_question",
                table: "user_answer",
                column: "id_question");

            migrationBuilder.CreateIndex(
                name: "IX_user_answer_id_user",
                table: "user_answer",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_user_progress_topic_id_question",
                table: "user_progress_topic",
                column: "id_question");

            migrationBuilder.CreateIndex(
                name: "IX_user_progress_topic_id_topic",
                table: "user_progress_topic",
                column: "id_topic");

            migrationBuilder.CreateIndex(
                name: "IX_user_progress_topic_id_user",
                table: "user_progress_topic",
                column: "id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "user_answer");

            migrationBuilder.DropTable(
                name: "user_progress_topic");

            migrationBuilder.DropTable(
                name: "alternative");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "lesson");
        }
    }
}
