using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Core.Application.Dtos.Account;
using RealEstateApp.Core.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace RealEstateApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Gestion de usuarios")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        [SwaggerOperation(
         Summary = "Login de usuario",
         Description = "Autentica un usuario en el sistema y le retorna un JWT"
     )]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost("registerAdmin")]
        [SwaggerOperation(
            Summary = "Creacion de usuario administrador",
            Description = "Recibe los parametros necesarios para crear un usuario con el rol administrador"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterDevUserAsync(request, origin));
        }

        [Authorize(Roles = "Admin")]


        [HttpPost("registerDev")]
        [SwaggerOperation(
        Summary = "Creacion de usuario desarrollador",
        Description = "Recibe los parametros necesarios para crear un usuario con el rol desarrollador"
        )]

        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> RegisterDevAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterDevUserAsync(request, origin));
        }

    }
}
