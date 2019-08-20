namespace StrumskaSlava.Web.ViewModels.News.Delete
{
    using System;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class NewsDeleteViewModel : IMapFrom<NewsServiceModel>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public NewsDeleteNewsCategoryViewModel NewsCategory { get; set; }

        public string Picture { get; set; }
    }
}
