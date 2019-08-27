namespace StrumskaSlava.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Common;
    using StrumskaSlava.Data;
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class MatchScheduleService : IMatchScheduleService
    {
        private readonly ApplicationDbContext context;

        public MatchScheduleService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateMatchSchedule(MatchScheduleServiceModel matchScheduleServiceModel)
        {
            MatchSchedule matchSchedule = matchScheduleServiceModel.To<MatchSchedule>();
            matchSchedule.MatchStatus.Name = GlobalConstants.MatchStatusActive;

            this.context.MatchSchedules.Add(matchSchedule);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            MatchSchedule gameFromDb = await this.context.MatchSchedules.SingleOrDefaultAsync(game => game.Id == id);

            this.context.Remove(gameFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> EditMatchSchedule(string id, MatchScheduleServiceModel matchScheduleServiceModel)
        {
            MatchSchedule gameFromDb = await this.context.MatchSchedules.SingleOrDefaultAsync(game => game.Id == id);

            if (gameFromDb == null)
            {
                throw new ArgumentNullException(nameof(gameFromDb));
            }

            gameFromDb.HomeTeam = matchScheduleServiceModel.HomeTeam;
            gameFromDb.GuestTeam = matchScheduleServiceModel.GuestTeam;
            gameFromDb.MatchDate = matchScheduleServiceModel.MatchDate;
            gameFromDb.HomeTeamScore = matchScheduleServiceModel.HomeTeamScore;
            gameFromDb.GuestTeamScore = matchScheduleServiceModel.GuestTeamScore;

            this.context.Update(gameFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<MatchScheduleServiceModel> GetAll()
        {
            return this.context.MatchSchedules.To<MatchScheduleServiceModel>();
        }

        public async Task<MatchScheduleServiceModel> GetById(string id)
        {
            var gameFromDb = await this.context.MatchSchedules.SingleOrDefaultAsync(game => game.Id == id);

            MatchScheduleServiceModel match = new MatchScheduleServiceModel
            {
                Id = gameFromDb.Id,
                HomeTeam = gameFromDb.HomeTeam,
                GuestTeam = gameFromDb.GuestTeam,
                HomeTeamScore = 0,
                GuestTeamScore = 0,
                MatchDate = gameFromDb.MatchDate,
            };

            return match;
        }
    }
}
