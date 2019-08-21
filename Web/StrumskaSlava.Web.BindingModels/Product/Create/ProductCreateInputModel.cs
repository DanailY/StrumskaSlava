namespace StrumskaSlava.Web.BindingModels.Product.Create
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using AutoMapper;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class ProductCreateInputModel : IMapTo<ProductServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ManufactureOn { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string ProductType { get; set; }

        [Required]
        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ProductCreateInputModel, ProductServiceModel>()
                .ForMember(d => d.ProductType, opts => opts.MapFrom(origin => new ProductTypeServiceModel
                {
                    Name = origin.ProductType
                }));
        }
    }
}
