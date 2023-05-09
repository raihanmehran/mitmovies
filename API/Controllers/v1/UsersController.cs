using Application.v1.DTOs;
using Application.v1.Services.UserService.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<ResponseMessage>> GetUserByUsername(string username)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByUsernameQuery { Username = username });

                if (result.StatusCode != 200) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("id/{userId}")]
        public async Task<ActionResult<ResponseMessage>> GetUserById(int userId)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByUserIdQuery { UserId = userId });

                if (result.StatusCode != 200) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}