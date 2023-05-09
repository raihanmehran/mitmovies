using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.UserService.Command
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseMessage>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseMessage> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateUserAsync(
                userUpdateDto: request.UserUpdateDto, userId: request.UserId);
        }
    }
}