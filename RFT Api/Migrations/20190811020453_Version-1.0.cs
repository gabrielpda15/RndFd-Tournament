using Microsoft.EntityFrameworkCore.Migrations;

namespace RFT.Api.Migrations
{
    public partial class Version10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rft_users_Teams_TeamAdminId",
                table: "rft_users");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayer_rft_players_PlayerId",
                table: "TeamPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayer_Teams_TeamId",
                table: "TeamPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_rft_tournament_TournamentId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamPlayer",
                table: "TeamPlayer");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "rft_teams");

            migrationBuilder.RenameTable(
                name: "TeamPlayer",
                newName: "rft_teamplayers");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_TournamentId",
                table: "rft_teams",
                newName: "IX_rft_teams_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamPlayer_TeamId",
                table: "rft_teamplayers",
                newName: "IX_rft_teamplayers_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rft_teams",
                table: "rft_teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rft_teamplayers",
                table: "rft_teamplayers",
                columns: new[] { "PlayerId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_rft_teamplayers_rft_players_PlayerId",
                table: "rft_teamplayers",
                column: "PlayerId",
                principalTable: "rft_players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rft_teamplayers_rft_teams_TeamId",
                table: "rft_teamplayers",
                column: "TeamId",
                principalTable: "rft_teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rft_teams_rft_tournament_TournamentId",
                table: "rft_teams",
                column: "TournamentId",
                principalTable: "rft_tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rft_users_rft_teams_TeamAdminId",
                table: "rft_users",
                column: "TeamAdminId",
                principalTable: "rft_teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rft_teamplayers_rft_players_PlayerId",
                table: "rft_teamplayers");

            migrationBuilder.DropForeignKey(
                name: "FK_rft_teamplayers_rft_teams_TeamId",
                table: "rft_teamplayers");

            migrationBuilder.DropForeignKey(
                name: "FK_rft_teams_rft_tournament_TournamentId",
                table: "rft_teams");

            migrationBuilder.DropForeignKey(
                name: "FK_rft_users_rft_teams_TeamAdminId",
                table: "rft_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rft_teams",
                table: "rft_teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rft_teamplayers",
                table: "rft_teamplayers");

            migrationBuilder.RenameTable(
                name: "rft_teams",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "rft_teamplayers",
                newName: "TeamPlayer");

            migrationBuilder.RenameIndex(
                name: "IX_rft_teams_TournamentId",
                table: "Teams",
                newName: "IX_Teams_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_rft_teamplayers_TeamId",
                table: "TeamPlayer",
                newName: "IX_TeamPlayer_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamPlayer",
                table: "TeamPlayer",
                columns: new[] { "PlayerId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_rft_users_Teams_TeamAdminId",
                table: "rft_users",
                column: "TeamAdminId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayer_rft_players_PlayerId",
                table: "TeamPlayer",
                column: "PlayerId",
                principalTable: "rft_players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayer_Teams_TeamId",
                table: "TeamPlayer",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_rft_tournament_TournamentId",
                table: "Teams",
                column: "TournamentId",
                principalTable: "rft_tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
