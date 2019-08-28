namespace StrumskaSlava.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using StrumskaSlava.Data;
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class LeagueTableService : ILeagueTableService
    {
        private readonly ApplicationDbContext context;

        public LeagueTableService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Edit(string id, LeagueTableServiceModel leagueTableServiceModel)
        {

            LeagueTable leagueTable = await this.context.LeagueTables.SingleOrDefaultAsync(team => team.Id == id);

            if (leagueTable == null)
            {
                throw new ArgumentNullException(nameof(leagueTable));
            }

            leagueTable.TeamName = leagueTableServiceModel.TeamName;
            leagueTable.MatchesPlayed = leagueTableServiceModel.MatchesPlayed;
            leagueTable.Wins = leagueTableServiceModel.Wins;
            leagueTable.Draws = leagueTableServiceModel.Draws;
            leagueTable.Losses = leagueTableServiceModel.Losses;
            leagueTable.GoalsAgainst = leagueTableServiceModel.GoalsAgainst;
            leagueTable.GoalsFor = leagueTableServiceModel.GoalsFor;
            leagueTable.Points = leagueTableServiceModel.Points;

            this.context.Update(leagueTable);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<LeagueTableServiceModel> GetAllTeams()
        {
            return this.context.LeagueTables.To<LeagueTableServiceModel>();
        }

        public async Task<LeagueTableServiceModel> GetById(string id)
        {
            return await this.context.LeagueTables.To<LeagueTableServiceModel>().SingleOrDefaultAsync(team => team.Id == id);
        }
    }
}
