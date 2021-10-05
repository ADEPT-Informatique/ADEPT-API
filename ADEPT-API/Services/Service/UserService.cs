using ADEPT_API.Models;
using ADEPT_API.Repositories.IRepository;
using ADEPT_API.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Services.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository pUserRepository)
        {
            _userRepository = pUserRepository;
        }
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
                Role = UserRoles.Membre
            });

            _userRepository.Add(user);
            _userRepository.Save();


            return user;
        }
    }
}
