using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace StrumskaSlava.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinaryUltility;

        public CloudinaryService(Cloudinary cloudinaryUltility)
        {
            this.cloudinaryUltility = cloudinaryUltility;
        }

        public async Task<string> UploadPictureAync(IFormFile pictureFile, string fileName)
        {
            byte[] destinationData;

            using (var ms = new MemoryStream())
            {
                await pictureFile.CopyToAsync(ms);
                destinationData = ms.ToArray();
            }

            UploadResult uploadResult = null;

            using (var ms = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    Folder = "product_images",
                    File = new FileDescription(fileName, ms),
                };

                uploadResult = this.cloudinaryUltility.Upload(uploadParams);
            }

            return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
