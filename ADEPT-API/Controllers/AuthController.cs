using ADEPT_API.Dto;
using ADEPT_API.Services;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService pAuthService)
        {
            _authService = pAuthService;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateIn pInput)
        {
            if (CurrentUser != null)
                return Ok();
            else
            {
                //Créer un nouvel utilisateur, puisqu'il s'agit seulement d'un nouvel utilisateur ayant été authentifié auprès de Firebase, mais pas de notre base de donnée.
                return Unauthorized();
            }
            
        }
    }
}
