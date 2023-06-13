using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.RatedMovieService.Command;
using Application.v1.Services.UserService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class RatedMoviesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public RatedMoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<ResponseMessage>> AddMovieRating(RatedMovieDto ratedMovieDto)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddMovieRatingCommand
                {
                    RatedMovieDto = ratedMovieDto,
                    User = user
                });

                if (result.StatusCode == 200) return Ok(new { result.Message });

                return BadRequest(new { result.Message });
            }
            catch (Exception) { throw; }
        }

        [Authorize]
        [HttpDelete("remove/{movieId}")]
        public async Task<ActionResult<ResponseMessage>> RemoveRatedMovie(int movieId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new RemoveMovieRatingCommand
                {
                    MovieId = movieId,
                    User = user
                });

                if (result.StatusCode == 200) return Ok(new { result.Message });

                return BadRequest(new { result.Message });
            }
            catch (Exception) { throw; }
        }

    }
}