using Application.v1.DTOs;
using Application.v1.Interfaces;
using Infrastructure.v1.Contexts;
using TMDbLib.Objects.People;

namespace Infrastructure.v1.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TmdbContext _tmdbContext;
        public PersonRepository(TmdbContext tmdbContext)
        {
            _tmdbContext = tmdbContext;
        }
        public async Task<ResponseMessage> GetPersonById(int personId)
        {
            ResponseMessage result = new ResponseMessage();

            result.Data = await _tmdbContext.client
                .GetPersonAsync(personId: personId,
                    PersonMethods.MovieCredits
                    | PersonMethods.Images
                    | PersonMethods.Changes
                    | PersonMethods.TvCredits);

            return result;
        }
    }
}