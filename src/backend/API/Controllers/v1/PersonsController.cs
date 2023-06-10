using Application.v1.DTOs;
using Application.v1.Services.PersonService.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class PersonsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public PersonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> GetPopularPeople()
        {
            try
            {
                var result = await _mediator.Send(new GetPopularPeopleQuery { });

                if (result.Data == null) return NotFound();

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<ResponseMessage>> GetPersonById(int personId)
        {
            try
            {
                var result = await _mediator.Send(new GetPersonByIdQuery { PersonId = personId });

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