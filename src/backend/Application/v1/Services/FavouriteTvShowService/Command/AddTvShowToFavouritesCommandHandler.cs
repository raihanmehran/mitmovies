using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.FavouriteTvShowService.Command
{
    public class AddTvShowToFavouritesCommandHandler : IRequestHandler<AddTvShowToFavouritesCommand, ResponseMessage>
    {
        private readonly IFavouriteTvShowsRepository _favouriteTvShowsRepository;
        public AddTvShowToFavouritesCommandHandler(IFavouriteTvShowsRepository favouriteTvShowsRepository)
        {
            _favouriteTvShowsRepository = favouriteTvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(AddTvShowToFavouritesCommand request, CancellationToken cancellationToken)
        {
            return await _favouriteTvShowsRepository.AddTvShowToFavourites(
                tvShowId: request.TvShowId, user: request.User);
        }
    }
}