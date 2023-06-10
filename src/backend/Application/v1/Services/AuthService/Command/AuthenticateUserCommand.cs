using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.AuthService.Command
{
    public class AuthenticateUserCommand : IRequest<ResponseMessage>
    {
        public AuthDto AuthDto { get; set; }
    }
}