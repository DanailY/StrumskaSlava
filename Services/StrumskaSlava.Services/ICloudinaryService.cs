namespace StrumskaSlava.Services
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<string> UploadPictureAync(IFormFile pictureFile, string fileName);
    }
}
