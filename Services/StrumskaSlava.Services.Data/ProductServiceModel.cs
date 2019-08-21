namespace StrumskaSlava.Services.Data
{
    using System;

    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class ProductServiceModel : IMapFrom<Product>, IMapTo<Product>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ProductTypeId { get; set; }

        public ProductTypeServiceModel ProductType { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }
    }
}
