using Application.v1.DTOs;
using Application.v1.Interfaces;
using Application.v1.Utils;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.v1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AppUser> GetUserByUserIdAsync(int userId)
        {
            return await _context.Users
                .Include(x => x.Photos)
                .Include(x => x.FavouriteMovies)
                .Include(x => x.FavouritePeople)
                .Include(x => x.FavouriteTvShows)
                .Include(x => x.WatchedMovies)
                .Include(x => x.WatchedTvShows)
                .Include(x => x.UserGenres)
                .SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ResponseMessage> UpdateUserAsync(UserUpdateDto userUpdateDto, int userId)
        {
            if (userUpdateDto is null || userId <= 0) return Response(
                statusCode: 404, message: "Validation Error: Data Not Provided");

            var user = await GetUserByUserIdAsync(userId: userId);

            if (user is null) Response(
                statusCode: 404, message: "User Not Found");

            _mapper.Map(userUpdateDto, user);

            // _context.Entry(user).State = EntityState.Modified;
            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "User Updated");

            return Response(
                statusCode: 500, message: "Error Updating User");
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(x => x.Photos)
                .Include(x => x.FavouriteMovies)
                .Include(x => x.FavouritePeople)
                .Include(x => x.FavouriteTvShows)
                .Include(x => x.WatchedMovies)
                .Include(x => x.WatchedTvShows)
                .Include(x => x.UserGenres)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<ResponseMessage> GetMemberByUserIdAsync(int userId)
        {
            if (userId <= 0) return Response(
                statusCode: 404, message: "User Id Not Provided");

            var reuslt = await _context.Users
                .Where(u => u.Id == userId)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            return Response(statusCode: 200, message: "User Found", data: reuslt);
        }

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        {
            var query = _context.Users.AsQueryable();
            query = query.Where(u => u.UserName != userParams.CurrentUsername);
            
            query = userParams.OrderBy switch
            {
                "created" => query.OrderByDescending(u => u.Created),
                _ => query.OrderByDescending(u => u.LastActive)
            };

            return await PagedList<MemberDto>.CreateAsync(
                source: query.AsNoTracking()
                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider),
                pageNumber: userParams.PageNumber,
                pageSize: userParams.PageSize);
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