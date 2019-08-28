namespace StrumskaSlava.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddLeagueTableModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeagueTables",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    TeamName = table.Column<string>(nullable: true),
                    MatchesPlayed = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Draws = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    GoalsFor = table.Column<int>(nullable: false),
                    GoalsAgainst = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueTables", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueTables");
        }
    }
}
