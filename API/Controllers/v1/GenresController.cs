using Application.v1.DTOs;
using Application.v1.Services.GenreService.Command;
using Application.v1.Services.GenreService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Authorize(Policy = "RequireAdminRole")]
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

        [HttpPost("update")]
        public async Task<ActionResult<ResponseMessage>> UpdateGenre(GenreDto genreDto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateGenreCommand
                {
                    Genre = genreDto
                });

                if (result.StatusCode == 200) return Ok(result.Message);

                return BadRequest(result.Message);
            }
            catch (Exception) { throw; }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> GetGenres()
        {
            try
            {
                var result = await _mediator.Send(new GetGenresQuery { });

                if (result.StatusCode == 200) return Ok(result.Data);

                return BadRequest(result.Message);
            }
            catch (Exception) { throw; }
        }

        [HttpGet("{genreId}")]
        public async Task<ActionResult<ResponseMessage>> GetGenreById(int genreId)
        {
            try
            {
                var result = await _mediator.Send(new GetGenreByIdQuery { GenreId = genreId });

                if (result.StatusCode == 200) return Ok(result.Data);

                return BadRequest(result.Message);
            }
            catch (Exception) { throw; }
        }
    }
}