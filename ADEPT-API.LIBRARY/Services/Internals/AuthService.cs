using ADEPT_API.DATABASE.Repositories;

namespace ADEPT_API.LIBRARY.Services.Internals
{
    internal class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository pAuthRepository)
        {
            _authRepository = pAuthRepository;
        }

    }
}
