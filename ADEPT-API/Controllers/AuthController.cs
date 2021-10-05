﻿using ADEPT_API.Dto;
using ADEPT_API.Models;
using ADEPT_API.Services;
using ADEPT_API.Services.IService;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADEPT_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IAuthService pAuthService, IUserService pUserService)
        {
            _authService = pAuthService;
            _userService = pUserService;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateIn pInput)
        {
            // Création d'un nouvel utilisateur si celui-ci est Authorized, mais où le current user est null.
            // L'utilisation du body n'est nécessaire que pour la création du compte, puisque l'information est plus complexe à obtenir en back-end qu'en front-end.

            User currentUser = this.CurrentUser;
            UserSummary user;
            if (CurrentUser != null)
            {
                user = new UserSummary
                {
                    Id = currentUser.Id,
                    Email = currentUser.Email,
                    Username = currentUser.Username
                };
            }
            else
            {
                User newUser = _userService.CreateUser(this.User.Claims.FirstOrDefault(x => x.Type.ToUpper() == "USER_ID")?.Value, pInput.Username, pInput.Email);
                user = new UserSummary()
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