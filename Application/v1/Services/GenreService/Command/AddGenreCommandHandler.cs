using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.GenreService.Command
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, ResponseMessage>
    {
        private readonly IGenresRepository _genresRepository;
        public AddGenreCommandHandler(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }
        public async Task<ResponseMessage> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            return await _genresRepository.AddGenre(genreDto: request.Genre);
        }
    }
}