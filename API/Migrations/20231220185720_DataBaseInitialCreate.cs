using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Choices_CorrectAnswerId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CorrectAnswerId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswerId",
                table: "Questions",
                newName: "AnswerId");

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    CorrectChoiceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Choices_CorrectChoiceId",
                        column: x => x.CorrectChoiceId,
                        principalTable: "Choices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CorrectChoiceId",
                table: "Answers",
                column: "CorrectChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "Questions",
                newName: "CorrectAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CorrectAnswerId",
                table: "Questions",
                column: "CorrectAnswerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Choices_CorrectAnswerId",
                table: "Questions",
                column: "CorrectAnswerId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
