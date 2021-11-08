using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Authenticate a user
        /// </summary>
        /// <param name="firebaseId">The firebase id</param>
        /// <param name="authenticateInDto">The authenticate request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<UserSummaryDto> AuthenticateUserAsync(string firebaseId, AuthenticateInDto authenticateInDto, CancellationToken cancellationToken);
    }
}
