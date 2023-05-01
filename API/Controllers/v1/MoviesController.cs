using Application.v1.DTOs;
using Application.v1.Services.MovieService.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class MoviesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<ResponseMessage>> GetMovieById(int movieId)
        {
            try
            {
                var result = await _mediator.Send(new GetMovieByIdQuery { MovieId = movieId });

                if (result.Data == null) return NotFound(result);

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("details/{movieId}")]
        public async Task<ActionResult<ResponseMessage>> GetMovieDetailById(int movieId)
        {
            try
            {
                var result = await _mediator.Send(new GetMovieDetailByIdQuery { MovieId = movieId });

                if (result.Data == null) return NotFound(result);

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("search/{payload}")]
        public async Task<ActionResult<ResponseMessage>> SearchMovie(string payload)
        {
            try
            {
                var result = await _mediator.Send(new SearchMovieQuery { Payload = payload });

                if (result.Data == null) return NotFound(result.Data);

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}