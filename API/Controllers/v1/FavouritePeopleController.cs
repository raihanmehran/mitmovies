using API.Extensions;
using Application.v1.DTOs;
using Application.v1.Services.FavouritePersonService.Command;
using Application.v1.Services.UserService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Authorize]
    public class FavouritePeopleController : BaseApiController
    {
        private readonly IMediator _mediator;
        public FavouritePeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{personId}")]
        public async Task<ActionResult<ResponseMessage>> AddPersonToFavourites(int personId)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByUserIdQuery
                {
                    UserId = User.GetUserId()
                });

                var result = await _mediator.Send(new AddPersonToFavouriteCommand
                {
                    PersonId = personId,
                    User = user
                });

                if (result.StatusCode != 200) return BadRequest(result.Message);

                return Ok(result.Message);
            }
            catch (Exception) { throw; }
        }
    }
}