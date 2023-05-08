using Application.v1.DTOs;
using Application.v1.Interfaces;
using Infrastructure.v1.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.v1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
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
                data: result);

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