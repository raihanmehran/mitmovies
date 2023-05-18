using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface IAccountRepository
    {
        Task<ResponseMessage> RegisterUser(RegisterUserDto registerUserDto);
        Task<ResponseMessage> GetUsersWithRoleAsync();
    }
}