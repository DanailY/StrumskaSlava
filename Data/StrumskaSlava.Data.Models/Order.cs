﻿namespace StrumskaSlava.Data.Models
{

    using StrumskaSlava.Data.Common.Models;

    public class Order : BaseModel<string>
    {
        public int Quantity { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string OrderId { get; set; }

        public OrderStatus OrderStatus { get; set; }

    }
}
