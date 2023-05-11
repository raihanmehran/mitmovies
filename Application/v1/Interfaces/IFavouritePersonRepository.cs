using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IFavouritePersonRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddPersonToFavourite(int personId, AppUser user);
        Task<ResponseMessage> RemovePersonToFavourite(int personId, AppUser user);
        bool IsFavouritePersonExist(int personId, AppUser user);
    }
}