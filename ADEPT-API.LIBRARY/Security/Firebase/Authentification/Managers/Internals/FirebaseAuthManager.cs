using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.Exceptions;
using ADEPT_API.LIBRARY.Exceptions;
using ADEPT_API.LIBRARY.Firebase.Authentification.Adapters.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Firebase.Authentification.Managers.Internals
{
    internal class FirebaseAuthManager : IFirebaseAuthManager
    {
        private readonly IFirebaseAuthAdapter _firebaseAuthAdapter;
        private readonly IUserRepository _userRepository;
        public FirebaseAuthManager(IFirebaseAuthAdapter firebaseAuthAdapter, IUserRepository userRepository)
        {
            _firebaseAuthAdapter = firebaseAuthAdapter ?? throw new ArgumentNullException(nameof(firebaseAuthAdapter), $"{nameof(FirebaseAuthManager)} was expecting a value for {nameof(firebaseAuthAdapter)} but received null..");
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository), $"{nameof(FirebaseAuthManager)} was expecting a value for {nameof(userRepository)} but received null..");
        }

        public async Task<UserDto> GetUserToAuthenticateAsync(string firebaseId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var user = await _userRepository.GetUserByFirebaseIdAsync(firebaseId, cancellationToken);
            return user;
        }

        public async Task UpdateUserCustomClaims(Guid userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var customClaims = new Dictionary<string, object>();

            var user = (await _userRepository.GetUserByIdAsync(userId, cancellationToken)) ?? throw new NotFoundException(nameof(User), $"L'utilisateur {userId} n'existe pas.");
            customClaims.Add("adeptUserId", user.Id);
            customClaims.Add("roles", user.Roles.Select(x => x.Role.ToString()));

            await _firebaseAuthAdapter.AddCustomClaimsToUser(user.firebaseId, customClaims);
            await _firebaseAuthAdapter.RevokeTokenAsync(user.firebaseId);
        }

        public async Task VerifyUserTokenAsync(string userToken, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var verifiedToken = await _firebaseAuthAdapter.VerifyFirebaseToken(userToken);
            if (verifiedToken is null)
            {
                throw new UnAuthorizedException(nameof(User), "Vérification du token firebase a échouée.");
            }
        }
    }
}
