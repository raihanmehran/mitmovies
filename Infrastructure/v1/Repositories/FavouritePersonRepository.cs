using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;

namespace Infrastructure.v1.Repositories
{
    public class FavouritePersonRepository : IFavouritePersonRepository
    {
        private readonly DataContext _context;
        public FavouritePersonRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ResponseMessage> AddPersonToFavourite(int personId, AppUser user)
        {
            if (personId <= 0 || user is null) return Response(
                statusCode: 400, message: "Data Not Provided");

            if (IsFavouritePersonExist(personId: personId, user: user)) return Response(
                statusCode: 400, message: "You already added this person to favourites");

            var favouritePerson = new FavouritePerson
            {
                PersonId = personId,
                AppUserId = user.Id
            };

            user.FavouritePeople.Add(favouritePerson);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Person added to favourites");

            return Response(statusCode: 500,
                message: "Error While Adding Person to Favourites");
        }

        public bool IsFavouritePersonExist(int personId, AppUser user)
        {
            return (user.FavouritePeople.Any(x =>
                x.PersonId == personId)) ? true : false;
        }

        public async Task<ResponseMessage> RemovePersonToFavourite(int personId, AppUser user)
        {
            if (personId <= 0 || user is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (!IsFavouritePersonExist(personId: personId, user: user)) return Response(
                statusCode: 401, message: "The person already removed");

            var favouritePerson = GetFavouritePerson(personId, user);
            user.FavouritePeople.Remove(favouritePerson);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Person Removed From Favourites");

            return Response(statusCode: 500,
                message: "Error While Removing Person From Favourites");
        }

        private FavouritePerson GetFavouritePerson(int personId, AppUser user)
        {
            return user.FavouritePeople
                .SingleOrDefault(x => x.PersonId == personId);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
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