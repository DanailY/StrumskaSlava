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

    public class FootballPlayerService : IFootballPlayerService
    {
        private readonly ApplicationDbContext context;

        public FootballPlayerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreatePlayer(FootballPlayerServiceModel footballPlayerServiceModel)
        {
            PlayerPosition playerPositionFromDb = this.context.PlayerPositions
                .SingleOrDefault(playerPosition => playerPosition.Name == footballPlayerServiceModel.PlayerPosition.Name);

            if (playerPositionFromDb == null)
            {
                throw new ArgumentNullException(nameof(playerPositionFromDb));
            }

            FootballPlayer footballPlayer = footballPlayerServiceModel.To<FootballPlayer>();
            footballPlayer.PlayerPosition = playerPositionFromDb;

            this.context.FootballPlayers.Add(footballPlayer);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, FootballPlayerServiceModel footballPlayerServiceModel)
        {
            PlayerPosition playerPositionFromDb = await this.context.PlayerPositions
                .SingleOrDefaultAsync(playerPosition => playerPosition.Name == footballPlayerServiceModel.PlayerPosition.Name);

            if (playerPositionFromDb == null)
            {
                throw new ArgumentNullException(nameof(playerPositionFromDb));
            }

            FootballPlayer footballPlayerFromDb = await this.context.FootballPlayers.SingleOrDefaultAsync(player => player.Id == id);

            if (footballPlayerFromDb == null)
            {
                throw new ArgumentNullException(nameof(footballPlayerFromDb));
            }

            footballPlayerFromDb.Name = footballPlayerServiceModel.Name;
            footballPlayerFromDb.Country = footballPlayerServiceModel.Country;
            footballPlayerFromDb.Picture = footballPlayerServiceModel.Picture;
            footballPlayerFromDb.Age = footballPlayerServiceModel.Age;
            footballPlayerFromDb.Height = footballPlayerServiceModel.Height;
            footballPlayerFromDb.PlayerNumber = footballPlayerServiceModel.PlayerNumber;

            footballPlayerFromDb.PlayerPosition = playerPositionFromDb;

            this.context.Update(footballPlayerFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FootballPlayer footballPlayer = await this.context.FootballPlayers.SingleOrDefaultAsync(player => player.Id == id);

            this.context.Remove(footballPlayer);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<PlayerPositionServiceModel> GetAllPlayerPosition()
        {
            return this.context.PlayerPositions.To<PlayerPositionServiceModel>();
        }

        public IQueryable<FootballPlayerServiceModel> GetAllPlayers()
        {
            return this.context.FootballPlayers.To<FootballPlayerServiceModel>();
        }

        public async Task<FootballPlayerServiceModel> GetById(string id)
        {
            var somthing = await this.context.FootballPlayers.To<FootballPlayerServiceModel>().SingleOrDefaultAsync(player => player.Id == id);

            return somthing;
        }
    }
}
