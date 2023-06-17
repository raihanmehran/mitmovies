using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.WatchLaterMovieService.Command
{
    public class AddWatchLaterMovieCommandHandler : IRequestHandler<AddWatchLaterMovieCommand, ResponseMessage>
    {
        private readonly IWatchLaterRepository _watchLaterRepository;
        public AddWatchLaterMovieCommandHandler(IWatchLaterRepository watchLaterRepository)
        {
            _watchLaterRepository = watchLaterRepository;
        }
        public async Task<ResponseMessage> Handle(AddWatchLaterMovieCommand request, CancellationToken cancellationToken)
        {
            return await _watchLaterRepository.AddWatchLaterMovieAsync(watchLaterDto: request.WatchLaterMovieDto, user: request.User);
        }
    }
}