using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.AuthService.Command
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, ResponseMessage>
    {
        private readonly IAuthRepository _authRepository;
        public AuthenticateUserCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<ResponseMessage> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            return await _authRepository.AuthenticateUser(authDto: request.AuthDto);
        }
    }
}