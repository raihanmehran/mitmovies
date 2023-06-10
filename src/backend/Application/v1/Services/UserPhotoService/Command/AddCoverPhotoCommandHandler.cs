using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.UserPhotoService.Command
{
    public class AddCoverPhotoCommandHandler : IRequestHandler<AddCoverPhotoCommand, ResponseMessage>
    {
        private readonly IPhotoRepository _photoRepository;
        public AddCoverPhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public async Task<ResponseMessage> Handle(AddCoverPhotoCommand request, CancellationToken cancellationToken)
        {
            return await _photoRepository.AddCoverPhotoAsync(
                user: request.User, file: request.Photo);
        }
    }
}