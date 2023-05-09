using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.UserService.Command
{
    public class UpdateUserCommand : IRequest<ResponseMessage>
    {
        public int UserId { get; set; }
        public UserUpdateDto UserUpdateDto { get; set; }
    }
}