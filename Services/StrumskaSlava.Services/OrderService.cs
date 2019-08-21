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

    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CompleteOrder(string orderId)
        {
            Order orderFromDb = await this.context.Orders.SingleOrDefaultAsync(order => order.Id == orderId);

            orderFromDb.OrderStatus = await this.context.OrderStatuses
                .SingleOrDefaultAsync(orderStatus => orderStatus.Name == GlobalConstants.OrderStatusCompleted);

            this.context.Update(orderFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreateOrder(OrderServiceModel orderServiceModel)
        {
            Order order = orderServiceModel.To<Order>();

            order.OrderStatus = await this.context.OrderStatuses.SingleOrDefaultAsync(orderStatus => orderStatus.Name == GlobalConstants.OrderStatusActive);

            order.CreatedOn = DateTime.UtcNow;

            this.context.Orders.Add(order);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<OrderServiceModel> GetAll()
        {
            return this.context.Orders.To<OrderServiceModel>();
        }

        public async Task SetOrdersToReceipt(Receipt receipt)
        {
            List<Order> ordersFromDb = await this.context.Orders
                .Where(order => order.UserId == receipt.RecipientId && order.OrderStatus.Name == GlobalConstants.OrderStatusActive).ToListAsync();

            receipt.Orders = ordersFromDb;
        }
    }
}
