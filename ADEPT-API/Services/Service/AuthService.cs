using ADEPT_API.Dto;
using ADEPT_API.Models;
using ADEPT_API.Repositories.IRepository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ADEPT_API.Services.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository pAuthRepository)
        {
            _authRepository = pAuthRepository;
        }

    }
}
