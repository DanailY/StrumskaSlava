﻿namespace StrumskaSlava.Web.ViewModels.Product.Details
{
    using System;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class ProductDetailsViewModel : IMapFrom<ProductServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProductTupeName { get; set; }
    }
}
