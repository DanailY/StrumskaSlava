namespace StrumskaSlava.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using StrumskaSlava.Data;
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class GalleryService : IGalleryService
    {
        private readonly ApplicationDbContext context;

        public GalleryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(GalleryServiceModel galleryServiceModel)
        {
            List<Picture> picturesList = new List<Picture>();

            for (int i = 0; i < galleryServiceModel.Pictures.Count; i++)
            {
                Picture mappedPicture = new Picture
                {
                    Url = galleryServiceModel.Pictures[i],
                };
                picturesList.Add(mappedPicture);
            }

            Gallery gallery = new Gallery
            {
                Name = galleryServiceModel.Name,
                Pictures = picturesList,
            };

            this.context.Galleries.Add(gallery);
            int result = this.context.SaveChanges();

            return result > 0;
        }

        public IQueryable<GalleryServiceModel> GetAllGalleries()
        {
            List<Gallery> galleries = this.context.Galleries.ToList();
            List<Picture> pictures = this.context.Pictures.ToList();

            List<GalleryServiceModel> allGalleries = new List<GalleryServiceModel>();

            for (int i = 0; i < galleries.Count; i++)
            {
                List<string> tempPictureUrl = new List<string>();
                var currentGallery = galleries[i];

                var picturesFromGallery = pictures.Where(x => x.GalleryId == currentGallery.Id).ToList();

                for (int j = 0; j < picturesFromGallery.Count; j++)
                {
                    tempPictureUrl.Add(picturesFromGallery[j].Url);
                }

                GalleryServiceModel gallery = new GalleryServiceModel
                {
                    Id = galleries[i].Id,
                    Name = galleries[i].Name,
                    Pictures = tempPictureUrl,
                };

                allGalleries.Add(gallery);
            }

            return allGalleries.AsQueryable();
        }

        public async Task<GalleryServiceModel> GetById(string id)
        {
            var galleryFromDb = await this.context.Galleries.SingleOrDefaultAsync(galleryDb => galleryDb.Id == id);

            List<Picture> pictures = this.context.Pictures.ToList();

            List<string> tempPictureUrl = new List<string>();

            var picturesFromGallery = pictures.Where(x => x.GalleryId == galleryFromDb.Id).ToList();

            for (int j = 0; j < picturesFromGallery.Count; j++)
            {
                tempPictureUrl.Add(picturesFromGallery[j].Url);
            }

            GalleryServiceModel gallery = new GalleryServiceModel
            {
                Id = galleryFromDb.Id,
                Name = galleryFromDb.Name,
                Pictures = tempPictureUrl,
                CreatedOn= galleryFromDb.CreatedOn,
            };

            return gallery;
        }

        public async Task<bool> Delete(string id)
        {
            Gallery galleryFromDb = await this.context.Galleries.SingleOrDefaultAsync(gallery => gallery.Id == id);

            this.context.Remove(galleryFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
