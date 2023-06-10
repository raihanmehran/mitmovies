using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.FavouriteMovieService.Query
{
    public class GetFavouriteMoviesQueryHandler : IRequestHandler<GetFavouriteMoviesQuery, ResponseMessage>
    {
        private readonly IFavouriteMoviesRepository _favouriteMoviesRepository;
        public GetFavouriteMoviesQueryHandler(IFavouriteMoviesRepository favouriteMoviesRepository)
        {
            _favouriteMoviesRepository = favouriteMoviesRepository;
        }
        public async Task<ResponseMessage> Handle(GetFavouriteMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _favouriteMoviesRepository.GetFavouriteMoviesAsync(
                user: request.User);
        }
    }
}