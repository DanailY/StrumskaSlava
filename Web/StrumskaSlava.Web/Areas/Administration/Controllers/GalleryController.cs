namespace StrumskaSlava.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.BindingModels.Gallery;
    using StrumskaSlava.Web.ViewModels.Gallery.Delete;

    public class GalleryController : AdministrationController
    {
        private readonly IGalleryService galleryService;
        private readonly ICloudinaryService cloudinaryService;

        public GalleryController(IGalleryService galleryService, ICloudinaryService cloudinaryService)
        {
            this.galleryService = galleryService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        [Route("/Administration/Gallery/Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        [Route("/Administration/Gallery/Create")]
        public async Task<IActionResult> Create(GalleryCreateBindingModel galleryCreateBindingModel)
        {
            GalleryServiceModel galleryServiceModel = galleryCreateBindingModel.To<GalleryServiceModel>();

            List<string> pictureUrls = new List<string>();

            foreach (var picture in galleryCreateBindingModel.Pictures)
            {
                var pictureUrl = await this.cloudinaryService
                .UploadPictureAync(picture, galleryCreateBindingModel.Name);
                pictureUrls.Add(pictureUrl);
            }

            for (int i = 0; i < pictureUrls.Count; i++)
            {
                galleryServiceModel.Pictures[i] = pictureUrls[i];
            }

            this.galleryService.Create(galleryServiceModel);

            return this.Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            GalleryDeleteViewModel galleryDeleteViewModel = (await this.galleryService.GetById(id)).To<GalleryDeleteViewModel>();

            if (galleryDeleteViewModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            return this.View(galleryDeleteViewModel);
        }

        [HttpPost]
        [Route("/Administration/Gallery/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            await this.galleryService.Delete(id);

            return this.Redirect("/Gallery/All");
        }

    }
}