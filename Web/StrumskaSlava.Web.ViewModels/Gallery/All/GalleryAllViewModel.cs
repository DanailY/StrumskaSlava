namespace StrumskaSlava.Web.ViewModels.Gallery.All
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class GalleryAllViewModel : IMapFrom<GalleryServiceModel>
    {
        public GalleryAllViewModel()
        {
            this.PicturesUrl = new List<string>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public List<string> PicturesUrl { get; set; }
    }
}
