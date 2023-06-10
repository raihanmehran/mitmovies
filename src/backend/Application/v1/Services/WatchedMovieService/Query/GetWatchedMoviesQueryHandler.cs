using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchedMovieService.Query
{
    public class GetWatchedMoviesQueryHandler : IRequestHandler<GetWatchedMoviesQuery, ResponseMessage>
    {
        private readonly IWatchedMoviesRepository _watchedMoviesRepository;
        public GetWatchedMoviesQueryHandler(IWatchedMoviesRepository watchedMoviesRepository)
        {
            _watchedMoviesRepository = watchedMoviesRepository;
        }
        public async Task<ResponseMessage> Handle(GetWatchedMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _watchedMoviesRepository.GetWatchedMoviesAsync(
                user: request.User);
        }
    }
}