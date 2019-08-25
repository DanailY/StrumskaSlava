namespace StrumskaSlava.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using StrumskaSlava.Services.Data;

    public interface IGalleryService
    {
        bool Create(GalleryServiceModel galleryServiceModel);

        IQueryable<GalleryServiceModel> GetAllGalleries();

        Task<GalleryServiceModel> GetById(string id);

        Task<bool> Delete(string id);
    }
}
