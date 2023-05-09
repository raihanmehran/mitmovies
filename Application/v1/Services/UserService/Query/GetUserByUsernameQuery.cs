using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetUserByUsernameQuery : IRequest<AppUser>
    {
        public string Username { get; set; }
    }
}