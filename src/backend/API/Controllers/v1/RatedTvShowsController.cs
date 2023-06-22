using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.RatedTvShowService.Command;
using Application.v1.Services.UserService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class RatedTvShowsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public RatedTvShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<ResponseMessage>> AddTvShowRating(RatedTvShowDto ratedTvShowDto)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddTvShowRatingCommand
                {
                    RatedTvShowDto = ratedTvShowDto,
                    User = user
                });

                if (result.StatusCode == 200) return Ok(new { result.Message });

                return BadRequest(new { result.Message });
            }
            catch (Exception) { throw; }
        }

        [Authorize]
        [HttpDelete("remove/{tvShowId}")]
        public async Task<ActionResult<ResponseMessage>> RemoveRatedTvShow(int tvShowId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new RemoveTvShowRatingCommand
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