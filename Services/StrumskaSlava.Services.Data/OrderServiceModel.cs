namespace StrumskaSlava.Services.Data
{
    using System;

    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class OrderServiceModel : IMapFrom<Order>, IMapTo<Order>
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string OrderId { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
