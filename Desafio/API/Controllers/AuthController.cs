using API.Models;
using API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Authentication Controller
    /// </summary>
    [Authorize, ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authService">Auth Service</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="auth">user to be authenticated</param>
        /// <returns>Authenticated user</returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AuthenticateResponse))]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest auth)
        {
            var user = await _authService.Authenticate(auth.UserName, auth.Password).ConfigureAwait(false);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(new AuthenticateResponse(user));
        }
    }
}
