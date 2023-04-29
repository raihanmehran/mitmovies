using Application.v1.DTOs;
using Application.v1.Services.MovieService.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
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
    }
}