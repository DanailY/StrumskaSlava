

namespace StrumskaSlava.Web.BindingModels.News
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewsCreateBindingModel :  IMapTo<NewsServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string NewsCategory { get; set; }
        
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<NewsCreateBindingModel, NewsServiceModel>()
                .ForMember(d => d.NewsCategory, opts => opts.MapFrom(origin => new NewsCategoryServiceModel
                {
                    Name = origin.NewsCategory
                }));
        }
    }
}
