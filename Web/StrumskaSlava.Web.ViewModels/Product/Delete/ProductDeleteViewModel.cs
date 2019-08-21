namespace StrumskaSlava.Web.ViewModels.Product.Delete
{
    using System;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class ProductDeleteViewModel : IMapFrom<ProductServiceModel>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime ManufactureOn { get; set; }

        public string Picture { get; set; }

        public ProductDeleteProductTypeViewModel ProductType { get; set; }

        public string Description { get; set; }
    }
}
