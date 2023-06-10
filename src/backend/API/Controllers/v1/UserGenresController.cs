using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.UserGenreService.Command;
using Application.v1.Services.UserService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Authorize]
    public class UserGenresController : BaseApiController
    {
        private readonly IMediator _mediator;
        public UserGenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> UpdateUserGenres([FromQuery] string genres)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new UpdateUserGenresCommand
                {
                    Genres = genres,
                    User = user
                });

                if (result.StatusCode == 200) return Ok(result.Message);

                return BadRequest(result.Message);
            }
            catch (Exception) { throw; }
        }
    }
}