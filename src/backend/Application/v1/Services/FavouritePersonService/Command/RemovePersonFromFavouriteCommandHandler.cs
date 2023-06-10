using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.FavouritePersonService.Command
{
    public class RemovePersonFromFavouriteCommandHandler : IRequestHandler<RemovePersonFromFavouriteCommand, ResponseMessage>
    {
        private readonly IFavouritePersonRepository _favouritePersonRepository;
        public RemovePersonFromFavouriteCommandHandler(IFavouritePersonRepository favouritePersonRepository)
        {
            _favouritePersonRepository = favouritePersonRepository;
        }
        public async Task<ResponseMessage> Handle(RemovePersonFromFavouriteCommand request, CancellationToken cancellationToken)
        {
            return await _favouritePersonRepository.RemovePersonToFavouriteAsync(
                personId: request.PersonId, user: request.User);
        }
    }
}