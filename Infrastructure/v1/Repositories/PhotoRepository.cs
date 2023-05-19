using Application.v1.DTOs;
using Application.v1.Interfaces;
using AutoMapper;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.v1.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext _context;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        public PhotoRepository(DataContext context, IPhotoService photoService, IMapper mapper)
        {
            _mapper = mapper;
            _photoService = photoService;
            _context = context;
        }

        public async Task<ResponseMessage> AddProfilePhotoAsync(AppUser user, IFormFile file)
        {
            if (user is null) return Response(
                statusCode: 404, message: "User Not Found!");

            var result = await _photoService.AddPhotoAsync(
                file: file, storageFolder: "mitmovies-profile");

            if (result.Error != null) return Response(
                statusCode: 400, message: result.Error.Message);

            var newPhoto = new Photo
            {
                IsProfile = true,
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (user.Photos.Count > 0)
                foreach (var photo in user.Photos)
                {
                    if (photo.IsProfile) user.Photos.Remove(photo);
                }

            user.Photos.Add(newPhoto);

            if (await SaveAllAsync()) return Response(statusCode: 200,
                message: "Photo Added Successfully",
                data: _mapper.Map<PhotoDto>(newPhoto));

            return Response(statusCode: 500, message: "Failed to add profile picture");
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        private ResponseMessage Response(int statusCode, string message, object data = null)
        {
            var response = new ResponseMessage();
            response.StatusCode = statusCode;
            response.Message = message;
            response.Data = data;

            return response;
        }
    }
}