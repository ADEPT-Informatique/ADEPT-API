using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADEPT_API.DATABASE.Migrations
{
    public partial class MakeUserProgramIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_StudyPrograms_ProgramId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProgramId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StudyPrograms_ProgramId",
                table: "Users",
                column: "ProgramId",
                principalTable: "StudyPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_StudyPrograms_ProgramId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProgramId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StudyPrograms_ProgramId",
                table: "Users",
                column: "ProgramId",
                principalTable: "StudyPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
