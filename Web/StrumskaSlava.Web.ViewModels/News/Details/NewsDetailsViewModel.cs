namespace StrumskaSlava.Web.ViewModels.News.Details
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class NewsDetailsViewModel : IMapFrom<NewsServiceModel>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string NewsCategoryName { get; set; }

        public string Picture { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
