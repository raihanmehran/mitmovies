using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.UserService.Query;
using Application.v1.Services.WatchLaterTvShowService.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class WatchLaterTvShowsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public WatchLaterTvShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<ResponseMessage>> AddWatchLaterTvShow(WatchLaterDto watchLaterDto)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddWatchLaterTvShowCommand
                {
                    WatchLaterDto = watchLaterDto,
                    User = user
                });

                if (result.StatusCode == 200) return Ok(new { result.Message });

                return BadRequest(new { result.Message });
            }
            catch (Exception) { throw; }
        }

        [Authorize]
        [HttpDelete("remove/{tvShowId}")]
        public async Task<ActionResult<ResponseMessage>> RemoveWatchLaterTvShow(int tvShowId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new RemoveWatchLaterTvShowCommand
                {
                    TvShowId = tvShowId,
                    User = user
                });

                if (result.StatusCode == 200) return Ok(new { result.Message });

                return BadRequest(new { result.Message });
            }
            catch (Exception) { throw; }
        }
    }
}