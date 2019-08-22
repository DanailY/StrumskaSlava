namespace StrumskaSlava.Web.ViewModels.Receipt.All
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class ReceiptAllViewModel : IMapTo<ReceiptServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Total { get; set; }

        public int Products { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ReceiptServiceModel, ReceiptAllViewModel>()
                .ForMember(destination => destination.Total,
                    opts => opts.MapFrom(origin => origin.Orders.Sum(order => order.Product.Price * order.Quantity)))
                .ForMember(destination => destination.Products,
                    opts => opts.MapFrom(origin => origin.Orders.Sum(order => order.Quantity)));
        }
    }
}
