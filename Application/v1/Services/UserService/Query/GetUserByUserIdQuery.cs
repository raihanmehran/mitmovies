using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetUserByUserIdQuery : IRequest<ResponseMessage>
    {
        public int UserId { get; set; }
    }
}