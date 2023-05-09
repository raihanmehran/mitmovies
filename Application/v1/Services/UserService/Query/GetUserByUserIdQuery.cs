using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetUserByUserIdQuery : IRequest<AppUser>
    {
        public int UserId { get; set; }
    }
}