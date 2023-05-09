using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> GetUserByUsernameAsync(string username);
        Task<ResponseMessage> GetUserByUserIdAsync(int userId);
    }
}