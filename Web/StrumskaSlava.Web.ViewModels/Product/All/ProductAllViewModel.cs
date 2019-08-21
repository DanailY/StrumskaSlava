namespace StrumskaSlava.Web.ViewModels.Product.All
{
    using System;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class ProductAllViewModel : IMapFrom<ProductServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string ProductType { get; set; }

        public decimal Price { get; set; }
    }
}
