using StrumskaSlava.Services.Data;
using StrumskaSlava.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrumskaSlava.Web.ViewModels.Order.Cart
{
    public class OrderCartViewModel : IMapFrom<OrderServiceModel>
    {
        public string Id { get; set; }

        public string ProductPicture { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}
