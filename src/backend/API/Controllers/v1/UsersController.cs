using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.UserService.Command;
using Application.v1.Services.UserService.Query;
using Application.v1.Utils;
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

        [Authorize]
        [HttpGet("member-self")]
        public async Task<ActionResult<ResponseMessage>> GetLoggedMember()
        {
            try
            {
                var userId = User.GetUserId();

                var result = await _mediator.Send(new GetMemberByUserIdQuery { UserId = userId });

                if (result.StatusCode == 200) return Ok(result.Data);

                return NotFound(result.Message);
            }
            catch (Exception) { throw; }
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

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("members")]
        public async Task<ActionResult<PagedList<MemberDto>>> GetMembers([FromQuery] UserParams userParams)
        {
            try
            {
                userParams.CurrentUsername = User.GetUsername();

                var users = await _mediator.Send(new GetMembersQuery
                {
                    UserParams = userParams
                });

                Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage,
                    users.PageSize, users.TotalCount, users.TotalPages));

                return Ok(users);
            }
            catch (Exception) { throw; }
        }

    }
}