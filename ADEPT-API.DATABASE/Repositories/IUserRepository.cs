using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;
using ADEPT_API.DATACONTRACTS.Dto.Users.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Obtain users depending on the query request
        /// </summary>
        /// <param name="usersQueryDto">The request query</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <param name="orderField">The order field</param>
        /// <param name="orderDirection">The order direction</param>
        /// <param name="searches">Searches</param>
        /// <returns></returns>
        Task<IEnumerable<UserDto>> GetUsersByQueryAsync(UsersQueryDto usersQueryDto, CancellationToken cancellationToken, string orderField = null, OrderDirections orderDirection = OrderDirections.Asc, string searches = null);

        /// <summary>
        /// Create a user from a firebase token
        /// </summary>
        /// <param name="firebaseId">The firebase id</param>
        /// <param name="authenticateInDto">The authenticate dto</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<UserDto> CreateFirebaseUserAsync(string firebaseId, AuthenticateInDto authenticateInDto, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain a specific user
        /// </summary>
        /// <param name="userId">The user Id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain a specific user based on its firebaseId
        /// </summary>
        /// <param name="firebaseId">The firebase id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<UserDto> GetUserByFirebaseIdAsync(string firebaseId, CancellationToken cancellationToken);
    }
}
