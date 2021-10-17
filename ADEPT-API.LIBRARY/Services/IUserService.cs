using ADEPT_API.DATABASE.Models.Users;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IUserService
    {
        User CreateUser(string firebaseId, string username, string email);
    }
}
