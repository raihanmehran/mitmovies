using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.UserService.Query;
using Application.v1.Services.WatchedTvShowService.Command;
using Application.v1.Services.WatchedTvShowService.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class WatchedTvShowsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public WatchedTvShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{tvShowId}")]
        public async Task<ActionResult<ResponseMessage>> AddTvShowToWatched(int tvShowId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddTvShowToWatchedCommand
                {
                    TvShowId = tvShowId,
                    User = user
                });

                if (result.StatusCode != 200) return BadRequest(result.Message);

                return Ok(result.Message);
            }
            catch (Exception) { throw; }
        }

        [HttpPost("remove/{tvShowId}")]
        public async Task<ActionResult<ResponseMessage>> RemoveTvShowFromWatched(int TvShowId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new RemoveTvShowFromWatchedCommand
                {
                    TvShowId = TvShowId,
                    User = user
                });

                if (result.StatusCode != 200) return BadRequest(result.Message);

                return Ok(result.Message);
            }
            catch (Exception) { throw; }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> GetWatchedTvShows()
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new GetWatchedTvShowsQuery
                {
                    User = user
                });

                if (result.StatusCode == 200) return Ok(result.Data);

                return BadRequest(result.Message);
            }
            catch (Exception) { throw; }
        }
    }
}