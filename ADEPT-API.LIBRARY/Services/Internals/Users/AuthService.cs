using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;
using ADEPT_API.LIBRARY.Firebase.Authentification.Managers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services.Internals
{
    internal class AuthService : IAuthService
    {
        private readonly IFirebaseAuthManager _firebaseAuthManager;
        private readonly IUserRepository _userRepository;
        public AuthService(IFirebaseAuthManager firebaseAuthManager, IUserRepository userRepository)
        {
            _firebaseAuthManager = firebaseAuthManager ?? throw new ArgumentNullException(nameof(firebaseAuthManager), $"{nameof(AuthService)} was expecting a value for {nameof(firebaseAuthManager)} but received null..");
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository), $"{nameof(AuthService)} was expecting a value for {nameof(userRepository)} but received null..");
        }

        public async Task<UserSummaryDto> AuthenticateUserAsync(string firebaseId, AuthenticateInDto authenticateInDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _ = string.IsNullOrWhiteSpace(firebaseId) ? throw new ArgumentNullException(nameof(firebaseId), $"{nameof(AuthenticateUserAsync)} expected a value for {nameof(firebaseId)}.") : string.Empty;

            var authenticatedUser = await _firebaseAuthManager.GetUserToAuthenticateAsync(firebaseId, cancellationToken);
            if (authenticatedUser is null)
            {
                authenticatedUser = await _userRepository.CreateFirebaseUserAsync(firebaseId, authenticateInDto, cancellationToken);               
            }

            var result = new UserSummaryDto { Email = authenticateInDto.Email, Id = authenticatedUser.Id, Username = authenticatedUser.Username };
            return result;
        }

    }
}
