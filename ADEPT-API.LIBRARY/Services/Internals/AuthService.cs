using ADEPT_API.DATABASE.Repositories;
using System;

namespace ADEPT_API.LIBRARY.Services.Internals
{
    internal class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository pAuthRepository)
        {
            _authRepository = pAuthRepository ?? throw new ArgumentNullException($"{nameof(AuthService)} was expection a value for {nameof(pAuthRepository)} but received null..");
        }

    }
}
