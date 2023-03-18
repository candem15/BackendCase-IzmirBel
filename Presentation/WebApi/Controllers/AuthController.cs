using Application.Dtos.Token;
using Application.Features.Commands.Token.GetToken;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetPermission")]
        [ProducesResponseType(typeof(TokenDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTokenAsync([FromQuery]GetTokenCommandRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }
    }
}
