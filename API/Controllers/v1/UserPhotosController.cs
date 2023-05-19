using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.UserPhotoService.Command;
using Application.v1.Services.UserService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Authorize]
    public class UserPhotosController : BaseApiController
    {
        private readonly IMediator _mediator;
        public UserPhotosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("profile-photo/add")]
        public async Task<ActionResult<ResponseMessage>> AddProfilePhoto(IFormFile file)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddProfilePhotoCommand
                {
                    Photo = file,
                    User = user
                });

                if (result.StatusCode == 200) return Ok(result.Data);

                return BadRequest(result.Message);
            }
            catch (Exception) { throw; }
        }


    }
}