namespace StrumskaSlava.Data.Models
{
    using System.Collections.Generic;

    using StrumskaSlava.Data.Common.Models;

    public class Gallery : BaseModel<string>
    {
        public Gallery()
        {
            this.Pictures = new List<Picture>();
        }

        public string Name { get; set; }

        public virtual List<Picture> Pictures { get; set; }
    }
}
