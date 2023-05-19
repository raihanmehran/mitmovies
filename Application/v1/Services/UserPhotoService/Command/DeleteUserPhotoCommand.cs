using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.UserPhotoService.Command
{
    public class DeleteUserPhotoCommand : IRequest<ResponseMessage>
    {
        public AppUser User { get; set; }
        public int PhotoId { get; set; }
    }
}