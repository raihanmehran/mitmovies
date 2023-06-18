using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.UserService.Query;
using Application.v1.Services.WatchLaterMovieService.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class WatchLaterMoviesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public WatchLaterMoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<ResponseMessage>> AddWatchLaterMovie(WatchLaterDto watchLaterDto)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddWatchLaterMovieCommand
                {
                    WatchLaterMovieDto = watchLaterDto,
                    User = user
                });

                if (result.StatusCode == 200) return Ok(new { result.Message });

                return BadRequest(new { result.Message });
            }
            catch (Exception) { throw; }
        }
    }
}