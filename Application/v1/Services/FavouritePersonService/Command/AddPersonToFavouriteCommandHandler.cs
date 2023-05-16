using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.FavouritePersonService.Command
{
    public class AddPersonToFavouriteCommandHandler : IRequestHandler<AddPersonToFavouriteCommand, ResponseMessage>
    {
        private readonly IFavouritePersonRepository _favouritePersonRepository;
        public AddPersonToFavouriteCommandHandler(IFavouritePersonRepository favouritePersonRepository)
        {
            _favouritePersonRepository = favouritePersonRepository;
        }
        public async Task<ResponseMessage> Handle(AddPersonToFavouriteCommand request, CancellationToken cancellationToken)
        {
            return await _favouritePersonRepository.AddPersonToFavouriteAsync(
                personId: request.PersonId, user: request.User);
        }
    }
}