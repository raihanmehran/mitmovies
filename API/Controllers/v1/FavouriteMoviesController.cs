using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.FavouriteMovieService.Command;
using Application.v1.Services.FavouriteMovieService.Query;
using Application.v1.Services.UserService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Authorize]
    public class FavouriteMoviesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public FavouriteMoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{movieId}")]
        public async Task<ActionResult<ResponseMessage>> AddMovieToFavourite(int movieId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddMovieToFavouriteCommand
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
        public async Task<ActionResult<ResponseMessage>> RemoveMovieFromFavourites(int movieId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new RemoveMovieFromFavouritesCommand
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
        public async Task<ActionResult<ResponseMessage>> GetFavouriteMovies()
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new GetFavouriteMoviesQuery
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