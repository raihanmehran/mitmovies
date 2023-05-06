using Application.v1.DTOs;
using Application.v1.Services.AccountService.Command;
using Application.v1.Services.AuthService.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    public class AccountController : BaseApiController
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> AuthenticateUser(AuthDto authDto)
        {
            try
            {
                if (authDto is null) return BadRequest("Credential were not provided!");

                var result = await _mediator.Send(new AuthenticateUserCommand { AuthDto = authDto });

                if (result.StatusCode != 200) return Unauthorized(result.Message);

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("register")]
        public async Task<ActionResult<ResponseMessage>> RegisterUser(RegisterUserDto registerUserDto)
        {
            try
            {
                if (registerUserDto is null) return BadRequest("Empty user detected");

                var result = await _mediator.Send(new RegisterUserCommand { RegisterUserDto = registerUserDto });

                if (result.StatusCode != 200) return BadRequest(result.Message);

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}