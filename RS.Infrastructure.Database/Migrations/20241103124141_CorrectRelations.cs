using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scanner.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CorrectRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_GameVersion_GameVersionId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityStatHistory_ActivityStat_ActivityId",
                table: "ActivityStatHistory");

            migrationBuilder.DropIndex(
                name: "IX_Activity_GameVersionId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "GameVersionId",
                table: "Activity");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "SkillStat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                table: "ActivityStat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameVersionId",
                table: "ActivityStat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "ActivityStat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SkillStat_PlayerId",
                table: "SkillStat",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStat_ActivityId",
                table: "ActivityStat",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStat_GameVersionId",
                table: "ActivityStat",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStat_PlayerId",
                table: "ActivityStat",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityStat_Activity_ActivityId",
                table: "ActivityStat",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityStat_GameVersion_GameVersionId",
                table: "ActivityStat",
                column: "GameVersionId",
                principalTable: "GameVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityStat_Player_PlayerId",
                table: "ActivityStat",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityStatHistory_Activity_ActivityId",
                table: "ActivityStatHistory",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillStat_Player_PlayerId",
                table: "SkillStat",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityStat_Activity_ActivityId",
                table: "ActivityStat");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityStat_GameVersion_GameVersionId",
                table: "ActivityStat");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityStat_Player_PlayerId",
                table: "ActivityStat");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityStatHistory_Activity_ActivityId",
                table: "ActivityStatHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillStat_Player_PlayerId",
                table: "SkillStat");

            migrationBuilder.DropIndex(
                name: "IX_SkillStat_PlayerId",
                table: "SkillStat");

            migrationBuilder.DropIndex(
                name: "IX_ActivityStat_ActivityId",
                table: "ActivityStat");

            migrationBuilder.DropIndex(
                name: "IX_ActivityStat_GameVersionId",
                table: "ActivityStat");

            migrationBuilder.DropIndex(
                name: "IX_ActivityStat_PlayerId",
                table: "ActivityStat");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "SkillStat");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "ActivityStat");

            migrationBuilder.DropColumn(
                name: "GameVersionId",
                table: "ActivityStat");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "ActivityStat");

            migrationBuilder.AddColumn<Guid>(
                name: "GameVersionId",
                table: "Activity",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Activity_GameVersionId",
                table: "Activity",
                column: "GameVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_GameVersion_GameVersionId",
                table: "Activity",
                column: "GameVersionId",
                principalTable: "GameVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityStatHistory_ActivityStat_ActivityId",
                table: "ActivityStatHistory",
                column: "ActivityId",
                principalTable: "ActivityStat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
