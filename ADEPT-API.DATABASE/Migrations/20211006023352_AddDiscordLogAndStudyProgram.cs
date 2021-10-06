using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADEPT_API.DATABASE.Migrations
{
    public partial class AddDiscordLogAndStudyProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscordId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProgramId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "StudentNumber",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DiscordStatuLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTimestampUtc = table.Column<long>(type: "bigint", nullable: false),
                    ReservionLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordStatuLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscordStatuLogs_DiscordStatuLogs_ReservionLogId",
                        column: x => x.ReservionLogId,
                        principalTable: "DiscordStatuLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscordStatuLogs_Users_BannedId",
                        column: x => x.BannedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscordStatuLogs_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPrograms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProgramId",
                table: "Users",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscordStatuLogs_BannedId",
                table: "DiscordStatuLogs",
                column: "BannedId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscordStatuLogs_CreatedByUserId",
                table: "DiscordStatuLogs",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscordStatuLogs_ReservionLogId",
                table: "DiscordStatuLogs",
                column: "ReservionLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StudyPrograms_ProgramId",
                table: "Users",
                column: "ProgramId",
                principalTable: "StudyPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_StudyPrograms_ProgramId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DiscordStatuLogs");

            migrationBuilder.DropTable(
                name: "StudyPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProgramId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DiscordId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "Users");
        }
    }
}
