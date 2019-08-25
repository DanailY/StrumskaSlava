namespace StrumskaSlava.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.ViewModels.Gallery.All;
    using StrumskaSlava.Web.ViewModels.Gallery.Details;
    using StrumskaSlava.Web.ViewModels.Gallery.Delete;

    public class GalleryController : BaseController
    {
        private readonly IGalleryService galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<GalleryAllViewModel> allGalleries = new List<GalleryAllViewModel>();

            var galleries = this.galleryService.GetAllGalleries().ToList();

            for (int i = 0; i < galleries.Count; i++)
            {
                List<string> tempPictureUrl = new List<string>();

                var currentPictures = galleries[i].Pictures;

                for (int j = 0; j < currentPictures.Count; j++)
                {
                    tempPictureUrl.Add(currentPictures[j]);
                }

                GalleryAllViewModel gallery = new GalleryAllViewModel
                {
                    Id = galleries[i].Id,
                    Name = galleries[i].Name,
                    PicturesUrl = tempPictureUrl,
                };

                allGalleries.Add(gallery);
            }

            return this.View(allGalleries);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var galleryFromDb = await this.galleryService.GetById(id);

            List<string> tempPictureUrl = new List<string>();

            List<string> galleryPictures = galleryFromDb.Pictures.ToList();

            for (int i = 0; i < galleryPictures.Count; i++)
            {
                tempPictureUrl.Add(galleryPictures[i]);
            }

            GalleryDetailsViewModel galleryViewModel = new GalleryDetailsViewModel
            {
                Id = galleryFromDb.Id,
                Name = galleryFromDb.Name,
                PicturesUrl = tempPictureUrl,
            };

            return this.View(galleryViewModel);
        }
    }
}