namespace StrumskaSlava.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StrumskaSlava.Common;
    using StrumskaSlava.Data.Models;

    internal class OrderStatusSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.OrderStatuses.Any())
            {
                dbContext.OrderStatuses.Add(new OrderStatus
                {
                    Name = GlobalConstants.OrderStatusActive,
                });

                dbContext.OrderStatuses.Add(new OrderStatus
                {
                    Name = GlobalConstants.OrderStatusCompleted,
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
