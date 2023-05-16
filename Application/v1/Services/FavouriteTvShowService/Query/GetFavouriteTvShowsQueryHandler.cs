using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.FavouriteTvShowService.Query
{
    public class GetFavouriteTvShowsQueryHandler : IRequestHandler<GetFavouriteTvShowsQuery, ResponseMessage>
    {
        private readonly IFavouriteTvShowsRepository _favouriteTvShowsRepository;
        public GetFavouriteTvShowsQueryHandler(IFavouriteTvShowsRepository favouriteTvShowsRepository)
        {
            _favouriteTvShowsRepository = favouriteTvShowsRepository;
        }
        public async Task<ResponseMessage> Handle(GetFavouriteTvShowsQuery request, CancellationToken cancellationToken)
        {
            return await _favouriteTvShowsRepository.GetFavouriteTvShowsAsync(
                user: request.User);
        }
    }
}