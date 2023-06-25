using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.FavouriteTvShowService.Command;
using Application.v1.Services.FavouriteTvShowService.Query;
using Application.v1.Services.UserService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Authorize]
    public class FavouriteTvShowsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public FavouriteTvShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{tvShowId}")]
        public async Task<ActionResult<ResponseMessage>> AddTvShowToFavourites(int tvShowId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddTvShowToFavouritesCommand
                {
                    TvShowId = tvShowId,
                    User = user
                });

                if (result.StatusCode != 200) return BadRequest(new { result.Message });

                return Ok(new { result.Message });
            }
            catch (Exception) { throw; }
        }

        [HttpPost("remove/{tvShowId}")]
        public async Task<ActionResult<ResponseMessage>> RemoveTvShowFromFavourites(int tvShowId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new RemoveTvShowToFavouritesCommand
                {
                    TvShowId = tvShowId,
                    User = user
                });

                if (result.StatusCode != 200) return BadRequest(new { result.Message });

                return Ok(new { result.Message });
            }
            catch (Exception) { throw; }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> GetFavouriteTvShows()
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new GetFavouriteTvShowsQuery
                {
                    User = user
                });

                if (result.StatusCode == 200) return Ok(new { result.Message });

                return BadRequest(new { result.Message });
            }
            catch (Exception) { throw; }
        }
    }
}