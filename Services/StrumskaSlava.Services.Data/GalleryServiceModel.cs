namespace StrumskaSlava.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class GalleryServiceModel : IMapFrom<Gallery>, IMapTo<Gallery>
    {
        public GalleryServiceModel()
        {
            this.Pictures = new List<string>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<string> Pictures { get; set; }
    }
}
