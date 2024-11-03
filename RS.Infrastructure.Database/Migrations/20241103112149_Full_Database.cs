using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Scanner.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Full_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Name",
                table: "User");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.CreateTable(
                name: "ActivityStat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionName = table.Column<string>(type: "text", nullable: false),
                    Setting = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentSession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameVersion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GameVersionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AccountType = table.Column<int>(type: "integer", nullable: false),
                    GameVersionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillStat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameVersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Experience = table.Column<long>(type: "bigint", nullable: false),
                    Rank = table.Column<long>(type: "bigint", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillStat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillStat_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillStat_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityStatHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameVersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<long>(type: "bigint", nullable: false),
                    Rank = table.Column<long>(type: "bigint", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStatHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityStatHistory_ActivityStat_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "ActivityStat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityStatHistory_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityStatHistory_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillStatHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameVersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Experience = table.Column<long>(type: "bigint", nullable: false),
                    Rank = table.Column<long>(type: "bigint", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillStatHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillStatHistory_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillStatHistory_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillStatHistory_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameVersion",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("83cce0f7-3d54-437c-b4c1-3f270792fc8c"), "RS3" },
                    { new Guid("8d292ae5-87c6-44f6-a7a7-71898af17f52"), "OSRS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_GameVersionId",
                table: "Activity",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStatHistory_ActivityId",
                table: "ActivityStatHistory",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStatHistory_GameVersionId",
                table: "ActivityStatHistory",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStatHistory_PlayerId",
                table: "ActivityStatHistory",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameVersionId",
                table: "Player",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillStat_GameVersionId",
                table: "SkillStat",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillStat_SkillId",
                table: "SkillStat",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillStatHistory_GameVersionId",
                table: "SkillStatHistory",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillStatHistory_PlayerId",
                table: "SkillStatHistory",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillStatHistory_SkillId",
                table: "SkillStatHistory",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "ActivityStatHistory");

            migrationBuilder.DropTable(
                name: "CurrentSession");

            migrationBuilder.DropTable(
                name: "SkillStat");

            migrationBuilder.DropTable(
                name: "SkillStatHistory");

            migrationBuilder.DropTable(
                name: "ActivityStat");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "GameVersion");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.CreateIndex(
                name: "IX_User_Name",
                table: "User",
                column: "Name",
                unique: true);
        }
    }
}
