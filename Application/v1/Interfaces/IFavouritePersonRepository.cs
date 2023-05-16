using Application.v1.DTOs;
using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface IFavouritePersonRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddPersonToFavouriteAsync(int personId, AppUser user);
        Task<ResponseMessage> RemovePersonToFavouriteAsync(int personId, AppUser user);
        Task<ResponseMessage> GetFavouritePeopleAsync(AppUser user);
        bool IsFavouritePersonExist(int personId, AppUser user);
    }
}