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


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException($"{nameof(UserService)} was expection a value for {nameof(userRepository)} but received null..");
        }

        public object UserRoles { get; private set; }

        public User CreateUser(string firebaseId, string username, string email)
        {
            User user = new User()
            {
                FireBaseID = firebaseId,
                Username = username,
                Email = email
            };

            user.Roles.Add(new UserRole
            {
                User = user,
                Role = Roles.Membre
            });

            _userRepository.AddAsync(user);
            _userRepository.Save();

            return user;
        }
    }
}
