namespace StrumskaSlava.Services.Data
{

    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;
    using System;

    public class NewsServiceModel : IMapFrom<News>, IMapTo<News>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public string NewsCategoryId { get; set; }

        public NewsCategoryServiceModel NewsCategory { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
