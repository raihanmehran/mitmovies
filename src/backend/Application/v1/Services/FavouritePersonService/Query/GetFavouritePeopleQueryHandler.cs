using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.FavouritePersonService.Query
{
    public class GetFavouritePeopleQueryHandler : IRequestHandler<GetFavouritePeopleQuery, ResponseMessage>
    {
        private readonly IFavouritePersonRepository _favouritePersonRepository;
        public GetFavouritePeopleQueryHandler(IFavouritePersonRepository favouritePersonRepository)
        {
            _favouritePersonRepository = favouritePersonRepository;            
        }
        public async Task<ResponseMessage> Handle(GetFavouritePeopleQuery request, CancellationToken cancellationToken)
        {
            return await _favouritePersonRepository.GetFavouritePeopleAsync(
                user: request.User);            
        }
    }
}