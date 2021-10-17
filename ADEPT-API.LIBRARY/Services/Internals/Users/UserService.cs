using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;
using ADEPT_API.LIBRARY.Exceptions;
using ADEPT_API.LIBRARY.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.Services.Internals
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException($"{nameof(UserService)} was expection a value for {nameof(userRepository)} but received null..");
        }

        public async Task<UserDto> CreateFirebaseUserAsync(string firebaseId, AuthenticateInDto authenticateInDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(firebaseId))
            {
                throw new UserCreationFailureException(nameof(User).ToUpper(), $"Le firbaseId est empty ou null.");
            }

            var result = await _userRepository.CreateFirebaseUserAsync(firebaseId, authenticateInDto, cancellationToken);
            return result;
        }
    }
}
