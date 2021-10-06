using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Models.Users.Enums;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.LIBRARY.Services;
using System;

namespace ADEPT_API.Services.Internals
{
    internal class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository pUserRepository)
        {
            _userRepository = pUserRepository ?? throw new ArgumentNullException($"{nameof(UserService)} was expection a value for {nameof(pUserRepository)} but received null..");
        }

        public object UserRoles { get; private set; }

        public User CreateUser(string pFirebaseId, string pUsername, string pEmail)
        {
            User user = new User()
            {
                FireBaseID = pFirebaseId,
                Username = pUsername,
                Email = pEmail
            };

            user.Roles.Add(new UserRole
            {
                User = user,
                Role = Roles.Membre
            });

            _userRepository.Add(user);
            _userRepository.Save();

            return user;
        }
    }
}
