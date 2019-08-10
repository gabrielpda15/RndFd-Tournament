using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RFT.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rft_players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EditionUser = table.Column<string>(maxLength: 50, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Nickname = table.Column<string>(maxLength: 16, nullable: true),
                    Elo = table.Column<int>(nullable: false),
                    Roles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rft_players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rft_tournament",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EditionUser = table.Column<string>(maxLength: 50, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rft_tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rft_users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EditionUser = table.Column<string>(maxLength: 50, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 120, nullable: true),
                    Permission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rft_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rft_playertournament",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    TournamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rft_playertournament", x => new { x.PlayerId, x.TournamentId });
                    table.ForeignKey(
                        name: "FK_rft_playertournament_rft_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "rft_players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rft_playertournament_rft_tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "rft_tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rft_playertournament_TournamentId",
                table: "rft_playertournament",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rft_playertournament");

            migrationBuilder.DropTable(
                name: "rft_users");

            migrationBuilder.DropTable(
                name: "rft_players");

            migrationBuilder.DropTable(
                name: "rft_tournament");
        }
    }
}
