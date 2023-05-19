using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.UserPhotoService.Command
{
    public class DeleteUserPhotoCommandHandler : IRequestHandler<DeleteUserPhotoCommand, ResponseMessage>
    {
        private readonly IPhotoRepository _photoRepository;
        public DeleteUserPhotoCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public async Task<ResponseMessage> Handle(DeleteUserPhotoCommand request, CancellationToken cancellationToken)
        {
            return await _photoRepository.DeletePhotoAsync(
                user: request.User, photoId: request.PhotoId);
        }
    }
}