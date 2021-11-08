using ADEPT_API.DATACONTRACTS.Dto.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Firebase.Authentification.Managers
{
    public interface IFirebaseAuthManager
    {
        /// <summary>
        /// Update the custom claims of a specific user
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task UpdateUserCustomClaims(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Verfify the firebase token
        /// </summary>
        /// <param name="userToken">The firebase token</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task VerifyUserTokenAsync(string userToken, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain the user to authenticate through it's firebase Id
        /// </summary>
        /// <param name="firebaseId">The firebase id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<UserDto> GetUserToAuthenticateAsync(string firebaseId, CancellationToken cancellationToken);
    }
}