using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.AccountService.Command
{
    public class EditUserRolesCommand : IRequest<ResponseMessage>
    {
        public AppUser User { get; set; }
        public string Roles { get; set; }
    }
}