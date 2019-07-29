namespace StrumskaSlava.Data.Models
{
    using StrumskaSlava.Data.Common.Models;
    using StrumskaSlava.Data.Models.Enums;

    public class Gallery : BaseModel<string>
    {
        public string Name { get; set; }

        public GalleryType Type { get; set; }
    }
}
