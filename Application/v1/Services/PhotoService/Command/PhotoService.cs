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
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file, string photoType)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = GetTransformation(photoType: photoType),
                    Folder = GetStorageFolder(photoType: photoType)
                };

                uploadResult = await _cloudinary.UploadAsync(parameters: uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId: publicId);

            return await _cloudinary.DestroyAsync(parameters: deleteParams);
        }

        private string GetStorageFolder(string photoType)
        {
            var storageFolder = "";

            if (photoType == "Profile") storageFolder = "mitmovies-profile";

            else if (photoType == "Cover") storageFolder = "mitmovies-cover";

            return storageFolder;
        }

        private Transformation GetTransformation(string photoType)
        {
            var transformation = new Transformation();

            if (photoType == "Profile")
            {
                transformation.Width(150).Height(150)
                    .Crop("fill").Gravity("face");
            }
            else if (photoType == "Cover")
            {
                transformation.Width(820).Height(312)
                    .Crop("fill");
            }

            return transformation;
        }
    }
}
