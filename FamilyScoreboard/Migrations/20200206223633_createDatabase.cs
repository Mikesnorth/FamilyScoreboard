using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyScoreboard.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PointValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMemebers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PreferredName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMemebers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cost = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompletedChores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateEntered = table.Column<DateTimeOffset>(nullable: false),
                    PointsEarned = table.Column<int>(nullable: false),
                    ChoreId = table.Column<int>(nullable: true),
                    FamilyMemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedChores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedChores_Chores_ChoreId",
                        column: x => x.ChoreId,
                        principalTable: "Chores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompletedChores_FamilyMemebers_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMemebers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Redemption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<int>(nullable: false),
                    RedeptionDate = table.Column<DateTimeOffset>(nullable: false),
                    RewardId = table.Column<int>(nullable: true),
                    FamilyMemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redemption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Redemption_FamilyMemebers_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMemebers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Redemption_Rewards_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Rewards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedChores_ChoreId",
                table: "CompletedChores",
                column: "ChoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedChores_FamilyMemberId",
                table: "CompletedChores",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Redemption_FamilyMemberId",
                table: "Redemption",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Redemption_RewardId",
                table: "Redemption",
                column: "RewardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedChores");

            migrationBuilder.DropTable(
                name: "Redemption");

            migrationBuilder.DropTable(
                name: "Chores");

            migrationBuilder.DropTable(
                name: "FamilyMemebers");

            migrationBuilder.DropTable(
                name: "Rewards");
        }
    }
}
