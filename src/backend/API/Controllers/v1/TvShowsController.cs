using Application.v1.DTOs;
using Application.v1.Services.TvShowService.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class TvShowsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public TvShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("popular")]
        public async Task<ActionResult<ResponseMessage>> GetPopularTvShows()
        {
            try
            {
                var result = await _mediator.Send(new GetPopularTvShowsQuery { });

                if (result.Data == null) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("toprated")]
        public async Task<ActionResult<ResponseMessage>> GetTopRatedTvShows()
        {
            try
            {
                var result = await _mediator.Send(new GetTopRatedTvShowsQuery { });

                if (result.Data == null) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{tvShowId}")]
        public async Task<ActionResult<ResponseMessage>> GetTvShowById(int tvShowId)
        {
            try
            {
                var result = await _mediator.Send(new GetTvShowByIdQuery { TvShowId = tvShowId });

                if (result.Data == null) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception) { throw; }
        }

        [HttpGet("trending/{timeWindow}")]
        public async Task<ActionResult<ResponseMessage>> GetTrendingTvShows(string timeWindow)
        {
            try
            {
                var result = await _mediator.Send(new GetTrendingTvShowsQuery { TimeWindow = timeWindow });

                if (result.Data != null) return Ok(result.Data);

                return NotFound();
            }
            catch (Exception) { throw; }
        }

        [HttpGet("search")]
        public async Task<ActionResult<ResponseMessage>> SearchTvShows(string query)
        {
            try
            {
                var result = await _mediator.Send(new SearchTvShowsQuery { Query = query });

                if (result.Data != null) return Ok(result.Data);

                return NotFound();
            }
            catch (Exception) { throw; }
        }
    }
}