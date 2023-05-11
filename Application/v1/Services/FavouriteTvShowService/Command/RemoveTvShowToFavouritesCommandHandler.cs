using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.FavouriteTvShowService.Command
{
    public class RemoveTvShowToFavouritesCommandHandler : IRequestHandler<RemoveTvShowToFavouritesCommand, ResponseMessage>
    {
        private readonly IFavouriteTvShowsRepository _favouriteTvShowsRepository;
        public RemoveTvShowToFavouritesCommandHandler(IFavouriteTvShowsRepository favouriteTvShowsRepository)
        {
            _favouriteTvShowsRepository = favouriteTvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(RemoveTvShowToFavouritesCommand request, CancellationToken cancellationToken)
        {
            return await _favouriteTvShowsRepository.RemoveTvShowToFavourites(
                tvShowId: request.TvShowId, user: request.User);
        }
    }
}