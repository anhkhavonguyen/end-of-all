using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VFSolution.Common.Config;
using VFSolution.PIM.Infrastructure.Services.Authentication;

namespace VFSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("request")]
        public async Task<ActionResult> RequestTokenAsync([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _authService.IsAuthenticatedAsync(request);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }
    }
}