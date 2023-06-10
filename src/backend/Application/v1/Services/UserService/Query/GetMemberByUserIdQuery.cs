using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetMemberByUserIdQuery : IRequest<ResponseMessage>
    {
        public int UserId { get; set; }
    }
}