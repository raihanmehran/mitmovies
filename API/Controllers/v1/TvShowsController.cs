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

        [HttpGet]
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
    }
}