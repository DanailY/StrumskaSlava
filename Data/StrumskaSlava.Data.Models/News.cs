namespace StrumskaSlava.Data.Models
{
    using StrumskaSlava.Data.Common.Models;

    public class News : BaseModel<string>
    {
        public string Title { get; set; }

        public NewsCategory Category { get; set; }

        public string CategoryId { get; set; }
    }
}
