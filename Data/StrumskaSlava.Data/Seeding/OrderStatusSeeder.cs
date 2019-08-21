namespace StrumskaSlava.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StrumskaSlava.Data.Models;

    internal class OrderStatusSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.OrderStatuses.Any())
            {
                dbContext.OrderStatuses.Add(new OrderStatus
                {
                    Name = "Active",
                });

                dbContext.OrderStatuses.Add(new OrderStatus
                {
                    Name = "Completed",
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
