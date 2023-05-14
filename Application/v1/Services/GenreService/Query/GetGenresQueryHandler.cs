using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.GenreService.Query
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, ResponseMessage>
    {
        private readonly IGenresRepository _genresRepository;
        public GetGenresQueryHandler(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }
        public async Task<ResponseMessage> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            return await _genresRepository.GetGenresAsync();
        }
    }
}