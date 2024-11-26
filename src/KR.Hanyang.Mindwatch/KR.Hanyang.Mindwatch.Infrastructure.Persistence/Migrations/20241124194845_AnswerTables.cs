using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AnswerTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionnaireRuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpenDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InitiatedByEmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireRuns_Employees_InitiatedByEmployeeId",
                        column: x => x.InitiatedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionnaireRuns_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    QuestionnaireRunId = table.Column<int>(type: "int", nullable: false),
                    AnsweredByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Employees_AnsweredByEmployeeId",
                        column: x => x.AnsweredByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_QuestionnaireRuns_QuestionnaireRunId",
                        column: x => x.QuestionnaireRunId,
                        principalTable: "QuestionnaireRuns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnsweredByEmployeeId",
                table: "Answers",
                column: "AnsweredByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionnaireRunId",
                table: "Answers",
                column: "QuestionnaireRunId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireRuns_InitiatedByEmployeeId",
                table: "QuestionnaireRuns",
                column: "InitiatedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireRuns_QuestionnaireId",
                table: "QuestionnaireRuns",
                column: "QuestionnaireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuestionnaireRuns");
        }
    }
}
