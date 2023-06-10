using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.GenreService.Command
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, ResponseMessage>
    {
        private readonly IGenresRepository _genresRepository;
        public UpdateGenreCommandHandler(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }
        public async Task<ResponseMessage> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            return await _genresRepository.UpdateGenreAsync(genreDto: request.Genre);
        }
    }
}