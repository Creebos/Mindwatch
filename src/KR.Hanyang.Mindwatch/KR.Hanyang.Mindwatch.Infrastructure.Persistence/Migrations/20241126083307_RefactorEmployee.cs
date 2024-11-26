using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Employees_AnsweredByEmployeeId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireRuns_Employees_InitiatedByEmployeeId",
                table: "QuestionnaireRuns");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Employees_CreatedByEmployeeId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_CreatedByEmployeeId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Answers_AnsweredByEmployeeId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CreatedByEmployeeId",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "AnsweredByEmployeeId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "InitiatedByEmployeeId",
                table: "QuestionnaireRuns",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionnaireRuns_InitiatedByEmployeeId",
                table: "QuestionnaireRuns",
                newName: "IX_QuestionnaireRuns_EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "QuestionnaireRunStatus",
                table: "QuestionnaireRuns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Commits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CommitDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommitSize = table.Column<int>(type: "int", nullable: false),
                    CommitType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commits_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupervisorEmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Employees_SupervisorEmployeeId",
                        column: x => x.SupervisorEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId",
                table: "Employees",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Commits_EmployeeId",
                table: "Commits",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SupervisorEmployeeId",
                table: "Teams",
                column: "SupervisorEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireRuns_Employees_EmployeeId",
                table: "QuestionnaireRuns",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_TeamId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireRuns_Employees_EmployeeId",
                table: "QuestionnaireRuns");

            migrationBuilder.DropTable(
                name: "Commits");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TeamId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "QuestionnaireRunStatus",
                table: "QuestionnaireRuns");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "QuestionnaireRuns",
                newName: "InitiatedByEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionnaireRuns_EmployeeId",
                table: "QuestionnaireRuns",
                newName: "IX_QuestionnaireRuns_InitiatedByEmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByEmployeeId",
                table: "Questionnaires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnsweredByEmployeeId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_CreatedByEmployeeId",
                table: "Questionnaires",
                column: "CreatedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnsweredByEmployeeId",
                table: "Answers",
                column: "AnsweredByEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Employees_AnsweredByEmployeeId",
                table: "Answers",
                column: "AnsweredByEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireRuns_Employees_InitiatedByEmployeeId",
                table: "QuestionnaireRuns",
                column: "InitiatedByEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_Employees_CreatedByEmployeeId",
                table: "Questionnaires",
                column: "CreatedByEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
