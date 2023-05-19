using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Application.v1.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file, string storageFolder);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}