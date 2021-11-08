using FirebaseAdmin.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Firebase.Authentification.Adapters.Internals
{
    public interface IFirebaseAuthAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firebaseId">the firebase id</param>
        /// <param name="customClaims">The custom claims</param>
        /// <returns></returns>
        Task AddCustomClaimsToUser(string firebaseId, IReadOnlyDictionary<string, object> customClaims);

        /// <summary>
        /// Verify the firebase token
        /// </summary>
        /// <param name="token">The firebase token</param>
        /// <returns></returns>
        Task<FirebaseToken> VerifyFirebaseToken(string token);

        /// <summary>
        /// Revoke a token firebase
        /// </summary>
        /// <param name="firebaseId">The firebase id</param>
        /// <returns></returns>
        Task RevokeTokenAsync(string firebaseId);
    }
}