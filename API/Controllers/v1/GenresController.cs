using Application.v1.DTOs;
using Application.v1.Services.GenreService.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class GenresController : BaseApiController
    {
        private readonly IMediator _mediator;
        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ResponseMessage>> AddGenre(GenreDto genreDto)
        {
            try
            {
                var result = await _mediator.Send(new AddGenreCommand
                {
                    Genre = genreDto
                });

                if (result.StatusCode == 200) return Ok(result.Message);

                return BadRequest(result.Message);
            }
            catch (Exception) { throw; }
        }
    }
}