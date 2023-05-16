using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.UserService.Command;
using Application.v1.Services.UserService.Query;
using Domain.v1.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<AppUser>> GetUserByUsername(string username)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByUsernameQuery { Username = username });

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("id/{userId}")]
        public async Task<ActionResult<AppUser>> GetUserById(int userId)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByUserIdQuery { UserId = userId });

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateUserCommand
                {
                    UserUpdateDto = userUpdateDto,
                    UserId = User.GetUserId()
                });

                if (result.StatusCode != 200) return BadRequest(result.Message);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("member/id/{userId}")]
        public async Task<ActionResult<ResponseMessage>> GetMemberById(int userId)
        {
            try
            {
                var result = await _mediator.Send(new GetMemberByUserIdQuery { UserId = userId });

                if (result.StatusCode != 200) return NotFound(result.Message);

                return Ok(result.Data);
            }
            catch (Exception) { throw; }
        }

    }
}