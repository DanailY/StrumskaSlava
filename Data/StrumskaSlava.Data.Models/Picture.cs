namespace StrumskaSlava.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Common.Models;

    public class Picture : BaseModel<string>
    {
        public string Url { get; set; }

        public string GalleryId { get; set; }

        public virtual Gallery Gallery { get; set; }
    }
}
