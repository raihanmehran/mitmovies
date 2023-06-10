using Application.v1.DTOs;
using Application.v1.Utils;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SaveAllAsync();
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<AppUser> GetUserByUserIdAsync(int userId);
        Task<ResponseMessage> UpdateUserAsync(UserUpdateDto userUpdateDto, int userId);
        Task<ResponseMessage> GetMemberByUserIdAsync(int userId);
        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    }
}