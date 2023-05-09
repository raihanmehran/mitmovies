using Application.v1.DTOs;
using Application.v1.Interfaces;
using AutoMapper;
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
            // if (userId <= 0) return Response(
            //     statusCode: 404, message: "User Id Not Provided");

            return await _context.Users.SingleOrDefaultAsync(x =>
                x.Id == userId);

            // if (result is null) return Response(
            //     statusCode: 404, message: "User Not Found");

            // return Response(statusCode: 200, message: "User Found",
            //     data: _mapper.Map<MemberDto>(result));
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
            return await _context.Users.SingleOrDefaultAsync(x =>
                x.UserName == username);
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