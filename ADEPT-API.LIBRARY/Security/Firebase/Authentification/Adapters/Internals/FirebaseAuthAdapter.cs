using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ADEPT_API.LIBRARY.Firebase.Authentification.Adapters.Internals
{
    internal class FirebaseAuthAdapter : IFirebaseAuthAdapter
    {
        public FirebaseAuthAdapter(GoogleCredential googleCredential, string projectId)
        {
            _ = googleCredential ?? throw new ArgumentNullException(nameof(googleCredential), "");
            _ = string.IsNullOrWhiteSpace(projectId) ? throw new ArgumentNullException(nameof(projectId), "") : projectId;

            var firebaseAppOptions = new AppOptions
            {
                Credential = googleCredential,
                ProjectId = projectId,
            };

            if (FirebaseApp.DefaultInstance is null)
            {
                FirebaseApp.Create(firebaseAppOptions);
            }
        }

        public async Task<FirebaseToken> VerifyFirebaseToken(string token)
        {
            return await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);

        }

        public async Task AddCustomClaimsToUser(string firebaseId, IReadOnlyDictionary<string, object> customClaims)
        {
            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(firebaseId, customClaims);
        }

        public async Task RevokeTokenAsync(string firebaseId)
        {
            await FirebaseAuth.DefaultInstance.RevokeRefreshTokensAsync(firebaseId);
        }
    }
}
