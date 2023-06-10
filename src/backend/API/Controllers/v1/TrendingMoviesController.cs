using Application.v1.DTOs;
using Application.v1.Services.TrendingMoviesService.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class TrendingMoviesController : BaseApiController
    {
        private readonly IMediator _mediator;
        public TrendingMoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("today")]
        public async Task<ActionResult<ResponseMessage>> GetTodayTrendingMovies()
        {
            try
            {
                var result = await _mediator.Send(new GetTodayTrendingMoviesQuery { });

                if (result.Data == null) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("week")]
        public async Task<ActionResult<ResponseMessage>> GetThisWeekTrendingMovies()
        {
            try
            {
                var result = await _mediator.Send(new GetThisWeekTrendingMoviesQuery { });

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