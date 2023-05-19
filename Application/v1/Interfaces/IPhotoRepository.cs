using Application.v1.DTOs;
using Domain.v1.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.v1.Interfaces
{
    public interface IPhotoRepository
    {
        Task<ResponseMessage> AddProfilePhotoAsync(AppUser user, IFormFile file);
        Task<ResponseMessage> DeletePhotoAsync(AppUser user, int photoId);
        Task<bool> SaveAllAsync();
    }
}