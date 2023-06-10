using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.UserPhotoService.Command
{
    public class AddProfilePhotoCommandHandler : IRequestHandler<AddProfilePhotoCommand, ResponseMessage>
    {
        private readonly IPhotoRepository _photoRepository;
        public AddProfilePhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public async Task<ResponseMessage> Handle(AddProfilePhotoCommand request, CancellationToken cancellationToken)
        {
            return await _photoRepository.AddProfilePhotoAsync(
                user: request.User, file: request.Photo);
        }
    }
}