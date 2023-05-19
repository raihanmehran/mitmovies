using Application.v1.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.v1.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Application.v1.Services.PhotoService.Command
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account: account);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file, string storageFolder)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500)
                        .Width(500).Crop("fill").Gravity("face"),
                    Folder = storageFolder
                };

                uploadResult = await _cloudinary.UploadAsync(parameters: uploadParams);
            }

            return uploadResult;
        }
    }
}