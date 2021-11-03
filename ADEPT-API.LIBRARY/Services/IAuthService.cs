using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firebaseId"></param>
        /// <param name="authenticateInDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<UserSummaryDto> AuthenticateUserAsync(string firebaseId, AuthenticateInDto authenticateInDto, CancellationToken cancellationToken);
    }
}
