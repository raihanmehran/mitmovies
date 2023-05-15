using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.UserGenreService.Command
{
    public class UpdateUserGenresCommandHandler : IRequestHandler<UpdateUserGenresCommand, ResponseMessage>
    {
        private readonly IUserGenresRepository _userGenresRepository;
        public UpdateUserGenresCommandHandler(IUserGenresRepository userGenresRepository)
        {
            _userGenresRepository = userGenresRepository;
        }
        public async Task<ResponseMessage> Handle(UpdateUserGenresCommand request, CancellationToken cancellationToken)
        {
            return await _userGenresRepository.UpdateUserGenresAsync(
                genres: request.Genres, user: request.User);
        }
    }
}