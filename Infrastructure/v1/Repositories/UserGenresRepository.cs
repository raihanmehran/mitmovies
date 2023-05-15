using System.Linq;
using Application.v1.DTOs;
using Application.v1.Interfaces;
using AutoMapper;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.v1.Repositories
{
    public class UserGenresRepository : IUserGenresRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UserGenresRepository(DataContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> UpdateUserGenresAsync(string genres, AppUser user)
        {
            if (user == null) return Response(
                statusCode: 404, message: "User Not Found");

            if (string.IsNullOrEmpty(genres)) return Response(
                statusCode: 400, message: "You must select at least one genres");

            var selectedGenresStringArray = genres.Split(",".ToArray());
            var selectedGenres = Array.ConvertAll(selectedGenresStringArray, int.Parse);
            bool changeDetected = false;

            foreach (var genreId in selectedGenres)
            {
                if (!user.UserGenres.Any(x => x.GenreId == genreId))
                {
                    user.UserGenres.Add(new UserGenre
                    {
                        GenreId = genreId,
                        AppUserId = user.Id
                    });
                    changeDetected = true;
                }
            }

            foreach (var genre in user.UserGenres)
            {
                if (!selectedGenres.Contains(genre.GenreId))
                {
                    user.UserGenres.Remove(genre);
                    changeDetected = true;
                }
            }

            if (!changeDetected) return Response(statusCode: 400, message: "No Changes To Apply");

            if (await SaveAllAsync()) return Response(statusCode: 200, message: "Genres Updated");

            return Response(statusCode: 500,
                message: "Error while updating User's Genres");
        }

        public async Task<bool> SaveAllAsync() =>
            await _context.SaveChangesAsync() > 0;

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