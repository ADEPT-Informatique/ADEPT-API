using ADEPT_API.LIBRARY.Firebase.Authentification.Managers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Security.Handlers
{
    public class AdeptRoleAuthorizationHandler : AttributeAuthorisationHandler<RoleAuthorizationRequirement, RolesAttribute>
    {

        private readonly IFirebaseAuthManager _firebaseAuthManager;
        public AdeptRoleAuthorizationHandler(IFirebaseAuthManager firebaseAuthManager)
        {
            _firebaseAuthManager = firebaseAuthManager ?? throw new ArgumentNullException(nameof(firebaseAuthManager), $"{nameof(AdeptRoleAuthorizationHandler)} was expecting a value for {nameof(firebaseAuthManager)} but received null..");
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAuthorizationRequirement requirement, IEnumerable<RolesAttribute> attributes)
        {
            var firebaseId = context.User.Identities.First().Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            if (!string.IsNullOrWhiteSpace(firebaseId))
            {
                var userToAuthenticate = await _firebaseAuthManager.GetUserToAuthenticateAsync(firebaseId, CancellationToken.None);
                if (userToAuthenticate is { })
                {
                    foreach (var attribute in attributes)
                    {
                        if (!context.HasSucceeded && userToAuthenticate.Roles.Select(r => r.Role.ToString()).Contains(attribute.RoleName))
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
            }
        }
    }
}
