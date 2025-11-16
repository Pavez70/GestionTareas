using gestionTareas.Application.Features.Auth.Login.Queries;
using gestionTareas.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gestionTareas.Controllers
{
    [Authorize]
    [Route("[Controller]/[Action]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost(Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] UserView usuario)
        {
            return Ok(await _mediator.Send(new LoginQuery(usuario.Email, usuario.Password)));
        }
    }
}
