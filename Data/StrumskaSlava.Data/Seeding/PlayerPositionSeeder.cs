namespace StrumskaSlava.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using StrumskaSlava.Common;
    using StrumskaSlava.Data.Models;

    internal class PlayerPositionSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.PlayerPositions.Any())
            {
                dbContext.PlayerPositions.Add(new PlayerPosition
                {
                    Name = GlobalConstants.PlayerPositionGoalkeeper,
                });

                dbContext.PlayerPositions.Add(new PlayerPosition
                {
                    Name = GlobalConstants.PlayerPositionDefender,
                });

                dbContext.PlayerPositions.Add(new PlayerPosition
                {
                    Name = GlobalConstants.PlayerPositionMidfielder,
                });

                dbContext.PlayerPositions.Add(new PlayerPosition
                {
                    Name = GlobalConstants.PlayerPositionForward,
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
