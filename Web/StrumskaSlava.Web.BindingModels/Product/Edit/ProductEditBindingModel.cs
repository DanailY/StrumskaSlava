namespace StrumskaSlava.Web.BindingModels.Product.Edit
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using AutoMapper;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;


    public class ProductEditBindingModel : IMapFrom<ProductServiceModel>, IMapTo<ProductServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string ProductType { get; set; }

        [Required]
        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ProductServiceModel, ProductEditBindingModel>()
                .ForMember(destination => destination.Picture,
                            opts => opts.Ignore())
                .ForMember(destination => destination.ProductType,
                            opts => opts.MapFrom(origin => origin.ProductType.Name));

            configuration
                .CreateMap<ProductEditBindingModel, ProductServiceModel>()
                .ForMember(d => d.ProductType, opts => opts.MapFrom(origin => new ProductTypeServiceModel
                {
                    Name = origin.ProductType
                }));
        }
    }
}
