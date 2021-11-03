using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;
using ADEPT_API.LIBRARY.Firebase.Authentification.Managers;
using ADEPT_API.LIBRARY.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService), $"{nameof(AuthController)} was expecting a value for {nameof(authService)} but received null..");
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateInDto authenticateInDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var user = await _authService.AuthenticateUserAsync(base.AuthenticatedFirebaseId, authenticateInDto, cancellationToken);
            return Ok(user);
        }
    }
}
