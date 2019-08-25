namespace StrumskaSlava.Web.ViewModels.Gallery.Delete
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class GalleryDeleteViewModel : IMapFrom<GalleryServiceModel>
    {
        public string Name { get; set; }
    }
}
