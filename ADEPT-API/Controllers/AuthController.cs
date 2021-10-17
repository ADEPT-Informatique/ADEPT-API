using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;
using ADEPT_API.LIBRARY.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ADEPT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService ?? throw new ArgumentNullException($"{nameof(AuthController)} was expecting a value for {nameof(authService)} but received null..");
            _userService = userService ?? throw new ArgumentNullException($"{nameof(AuthController)} was expecting a value for {nameof(userService)} but received null..");
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateInDto authenticateInDto)
        {
            // Création d'un nouvel utilisateur si celui-ci est Authorized, mais où le current user est null.
            // L'utilisation du body n'est nécessaire que pour la création du compte, puisque l'information est plus complexe à obtenir en back-end qu'en front-end.

            User currentUser = this.CurrentUser;
            UserSummaryDto user;
            if (CurrentUser != null)
            {
                user = new UserSummaryDto
                {
                    Id = currentUser.Id,
                    Email = currentUser.Email,
                    Username = currentUser.Username
                };
            }
            else
            {
                User newUser = _userService.CreateUser(this.User.Claims.FirstOrDefault(x => x.Type.ToUpper() == "USER_ID")?.Value, authenticateInDto.Username, authenticateInDto.Email);
                user = new UserSummaryDto()
                {
                    Id = newUser.Id,
                    Username = newUser.Username,
                    Email = newUser.Email
                };
            }

            return Ok(user);

        }
    }
}
