using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Create a user from a firebase Token
        /// </summary>
        /// <param name="firebaseId">The firebase id</param>
        /// <param name="authenticateInDto">The authenticate request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<UserDto> CreateFirebaseUserAsync(string firebaseId, AuthenticateInDto authenticateInDto, CancellationToken cancellationToken);
    }
}
