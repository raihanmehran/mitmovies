using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.GenreService.Query
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, ResponseMessage>
    {
        private readonly IGenresRepository _genresRepository;
        public GetGenreByIdQueryHandler(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }
        public async Task<ResponseMessage> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _genresRepository.GetGenreByIdAsync(
                genreId: request.GenreId);
        }
    }
}