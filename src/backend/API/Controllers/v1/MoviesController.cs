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

                if (result.Data == null) return NotFound(new { result.Message }); ;

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

                if (result.Data == null) return NotFound(new { result.Message }); ;

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<ResponseMessage>> SearchMovie(string query)
        {
            try
            {
                var result = await _mediator.Send(new SearchMovieQuery { Payload = query });

                if (result.Data == null) return NotFound(new { result.Message }); ;

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<ResponseMessage>> GetUpcomingMovies([FromQuery] int page)
        {
            try
            {
                var result = await _mediator.Send(new GetUpcomingMoviesQuery { Page = page });

                if (result.Data == null) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("popular")]
        public async Task<ActionResult<ResponseMessage>> GetPopularMovies([FromQuery] int page)
        {
            try
            {
                var result = await _mediator.Send(new GetPopularMoviesQuery { Page = page });

                if (result.Data == null) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("toprated")]
        public async Task<ActionResult<ResponseMessage>> GetTopRatedMovies([FromQuery] int page)
        {
            try
            {
                var result = await _mediator.Send(new GetTopRatedMoviesQuery { Page = page });

                if (result.Data == null) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}