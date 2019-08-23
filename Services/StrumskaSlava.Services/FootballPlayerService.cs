namespace StrumskaSlava.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

        public IQueryable<PlayerPositionServiceModel> GetAllPlayerPosition()
        {
            return this.context.PlayerPositions.To<PlayerPositionServiceModel>();
        }
    }
}
