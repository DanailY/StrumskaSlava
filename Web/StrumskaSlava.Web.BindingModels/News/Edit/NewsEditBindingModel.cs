using AutoMapper;
using Microsoft.AspNetCore.Http;
using StrumskaSlava.Services.Data;
using StrumskaSlava.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrumskaSlava.Web.BindingModels.News.Edit
{
    public class NewsEditBindingModel : IMapTo<NewsServiceModel>, IHaveCustomMappings
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
                .CreateMap<NewsServiceModel, NewsEditBindingModel>()
                .ForMember(destination => destination.Picture,
                            opts => opts.Ignore())
                .ForMember(destination => destination.NewsCategory,
                            opts => opts.MapFrom(origin => origin.NewsCategory.Name));

            configuration
                .CreateMap<NewsEditBindingModel, NewsServiceModel>()
                .ForMember(d => d.NewsCategory, opts => opts.MapFrom(origin => new NewsCategoryServiceModel
                {
                    Name = origin.NewsCategory
                }));
        }
    }
}
