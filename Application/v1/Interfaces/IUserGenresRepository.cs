using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IUserGenresRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> UpdateUserGenresAsync(string genres, AppUser user);
    }
}