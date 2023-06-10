using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IAccountRepository
    {
        Task<ResponseMessage> RegisterUser(RegisterUserDto registerUserDto);
        Task<ResponseMessage> GetUsersWithRoleAsync();
        Task<ResponseMessage> EditUserRolesAsync(AppUser user, string roles);
    }
}