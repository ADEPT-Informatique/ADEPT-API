using ADEPT_API.DATACONTRACTS.Dto.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Firebase.Authentification.Managers
{
    public interface IFirebaseAuthManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateUserCustomClaims(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task VerifyUserTokenAsync(string userToken, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firebaseId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<UserDto> GetUserToAuthenticateAsync(string firebaseId, CancellationToken cancellationToken);
    }
}