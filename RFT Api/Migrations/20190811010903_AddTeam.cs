using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RFT.Api.Migrations
{
    public partial class AddTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "rft_users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamAdminId",
                table: "rft_users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EditionUser = table.Column<string>(maxLength: 50, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    EloPoint = table.Column<int>(nullable: false),
                    Attempts = table.Column<int>(nullable: false),
                    TournamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_rft_tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "rft_tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayer",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayer", x => new { x.PlayerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TeamPlayer_rft_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "rft_players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPlayer_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rft_users_PlayerId",
                table: "rft_users",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rft_users_TeamAdminId",
                table: "rft_users",
                column: "TeamAdminId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayer_TeamId",
                table: "TeamPlayer",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TournamentId",
                table: "Teams",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_rft_users_rft_players_PlayerId",
                table: "rft_users",
                column: "PlayerId",
                principalTable: "rft_players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rft_users_Teams_TeamAdminId",
                table: "rft_users",
                column: "TeamAdminId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rft_users_rft_players_PlayerId",
                table: "rft_users");

            migrationBuilder.DropForeignKey(
                name: "FK_rft_users_Teams_TeamAdminId",
                table: "rft_users");

            migrationBuilder.DropTable(
                name: "TeamPlayer");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_rft_users_PlayerId",
                table: "rft_users");

            migrationBuilder.DropIndex(
                name: "IX_rft_users_TeamAdminId",
                table: "rft_users");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "rft_users");

            migrationBuilder.DropColumn(
                name: "TeamAdminId",
                table: "rft_users");
        }
    }
}
