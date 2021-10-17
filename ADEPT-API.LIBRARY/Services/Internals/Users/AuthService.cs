using ADEPT_API.DATABASE.Repositories;
using System;

namespace ADEPT_API.LIBRARY.Services.Internals
{
    internal class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository), $"{nameof(AuthService)} was expection a value for {nameof(authRepository)} but received null..");
        }

    }
}
