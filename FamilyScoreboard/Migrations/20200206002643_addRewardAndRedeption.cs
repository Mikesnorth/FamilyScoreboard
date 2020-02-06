using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyScoreboard.Migrations
{
    public partial class addRewardAndRedeption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cost = table.Column<int>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.Id);
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
                        name: "FK_Redemption_Reward_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Reward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Redemption");

            migrationBuilder.DropTable(
                name: "Reward");
        }
    }
}
