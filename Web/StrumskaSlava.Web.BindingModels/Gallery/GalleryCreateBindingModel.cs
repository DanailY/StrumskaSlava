using AutoMapper;
using Microsoft.AspNetCore.Http;
using StrumskaSlava.Services.Data;
using StrumskaSlava.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrumskaSlava.Web.BindingModels.Gallery
{
    public class GalleryCreateBindingModel : IMapTo<GalleryServiceModel>, IMapFrom<GalleryServiceModel>
    {
        public GalleryCreateBindingModel()
        {
            this.Pictures = new List<IFormFile>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public List<IFormFile> Pictures { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration
        //        .CreateMap<GalleryCreateBindingModel, GalleryServiceModel>()
        //        .ForMember(d => d.Pictures, opts => opts.MapFrom(origin => new PictureServiceModel
        //        {
        //            Url = origin.Pictures
        //        }));
        //}
    }
}
