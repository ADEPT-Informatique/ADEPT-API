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
        /// <param name="firebaseId"></param>
        /// <param name="customClaims"></param>
        /// <returns></returns>
        Task AddCustomClaimsToUser(string firebaseId, IReadOnlyDictionary<string, object> customClaims);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<FirebaseToken> VerifyFirebaseToken(string token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firebaseId"></param>
        /// <returns></returns>
        Task RevokeTokenAsync(string firebaseId);
    }
}