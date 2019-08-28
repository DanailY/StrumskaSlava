namespace StrumskaSlava.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StrumskaSlava.Common;
    using StrumskaSlava.Data.Models;

    internal class LeagueTableTeamsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.LeagueTables.Any())
            {
                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableStrumskaSlava,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableMontana,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableLokoSofia,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableLokoGorna,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableSpartakPleven,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableSpartakVarna,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableLitex,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableCska,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableKariana,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTablePomorie,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableChernomoretsBalchik,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableBotevGalabovo,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableHebar,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTablePirin,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableSeptemvri,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableNaftata,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                dbContext.LeagueTables.Add(new LeagueTable
                {
                    TeamName = GlobalConstants.LeagueTableLudogorets,
                    MatchesPlayed = GlobalConstants.InitialLeagueTableStats,
                    Wins = GlobalConstants.InitialLeagueTableStats,
                    Draws = GlobalConstants.InitialLeagueTableStats,
                    Losses = GlobalConstants.InitialLeagueTableStats,
                    GoalsFor = GlobalConstants.InitialLeagueTableStats,
                    GoalsAgainst = GlobalConstants.InitialLeagueTableStats,
                    Points = GlobalConstants.InitialLeagueTableStats,
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
