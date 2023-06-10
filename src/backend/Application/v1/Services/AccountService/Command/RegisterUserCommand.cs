using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.AccountService.Command
{
    public class RegisterUserCommand : IRequest<ResponseMessage>
    {
        public RegisterUserDto RegisterUserDto { get; set; }
    }
}