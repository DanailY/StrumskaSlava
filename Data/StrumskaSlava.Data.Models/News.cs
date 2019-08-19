namespace StrumskaSlava.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using StrumskaSlava.Data.Common.Models;

    public class News : BaseModel<string>, IDeletableEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public NewsCategory NewsCategory { get; set; }

        public string NewsCategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
