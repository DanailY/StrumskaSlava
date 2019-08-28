namespace StrumskaSlava.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StrumskaSlava.Common;
    using StrumskaSlava.Data.Models;

    internal class MatchStatusSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.MatchStatuses.Any())
            {
                dbContext.MatchStatuses.Add(new MatchStatus
                {
                    Name = GlobalConstants.MatchStatusActive,
                });

                dbContext.MatchStatuses.Add(new MatchStatus
                {
                    Name = GlobalConstants.MatchStatusCompleted,
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
