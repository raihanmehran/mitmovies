using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.UserService.Query;
using Application.v1.Services.WatchedMovieService.Command;
using Application.v1.Services.WatchedMovieService.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class WatchedMoviesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public WatchedMoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{movieId}")]
        public async Task<ActionResult<ResponseMessage>> AddMovieToWatched(int movieId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddMovieToWatchedCommand
                {
                    MovieId = movieId,
                    User = user
                });

                if (result.StatusCode != 200) return BadRequest(result.Message);

                return Ok(result.Message);
            }
            catch (Exception) { throw; }
        }

        [HttpPost("remove/{movieId}")]
        public async Task<ActionResult<ResponseMessage>> RemoveMovieFromWatched(int movieId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new RemoveMovieFromWatchedCommand
                {
                    MovieId = movieId,
                    User = user
                });

                if (result.StatusCode != 200) return BadRequest(result.Message);

                return Ok(result.Message);
            }
            catch (Exception) { throw; }

        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> GetWatchedMovies()
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new GetWatchedMoviesQuery
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