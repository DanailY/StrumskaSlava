namespace StrumskaSlava.Web.ViewModels.Gallery.Details
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class GalleryDetailsViewModel : IMapFrom<GalleryServiceModel>
    {
        public GalleryDetailsViewModel()
        {
            this.PicturesUrl = new List<string>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public List<string> PicturesUrl { get; set; }
    }
}
