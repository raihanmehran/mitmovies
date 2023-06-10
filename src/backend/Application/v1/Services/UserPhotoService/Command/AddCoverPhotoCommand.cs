using Application.v1.DTOs;
using Domain.v1.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.v1.Services.UserPhotoService.Command
{
    public class AddCoverPhotoCommand : IRequest<ResponseMessage>
    {
        public AppUser User { get; set; }
        public IFormFile Photo { get; set; }
    }
}