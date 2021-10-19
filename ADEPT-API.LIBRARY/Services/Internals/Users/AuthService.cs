using ADEPT_API.DATABASE.Repositories;
using System;

namespace ADEPT_API.LIBRARY.Services.Internals
{
    internal class AuthService : IAuthService
    {
        public AuthService(IAuthRepository authRepository)
        {
        }

    }
}
