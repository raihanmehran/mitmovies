using Application.v1.DTOs;
using Application.v1.Interfaces;
using AutoMapper;
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

        public async Task<ResponseMessage> GetUserByUserIdAsync(int userId)
        {
            if (userId <= 0) return Response(
                statusCode: 404, message: "User Id Not Provided");

            var result = await _context.Users.SingleOrDefaultAsync(x =>
                x.Id == userId);

            if (result is null) return Response(
                statusCode: 404, message: "User Not Found");

            return Response(statusCode: 200, message: "User Found",
                data: _mapper.Map<MemberDto>(result));
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<ResponseMessage> IUserRepository.GetUserByUsernameAsync(string username)
        {
            var result = await _context.Users.SingleOrDefaultAsync(x =>
                x.UserName == username);

            if (result is null) return Response(
                statusCode: 404, message: "User Not Found");

            return Response(statusCode: 200, message: "User Found",
                data: _mapper.Map<MemberDto>(result));

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