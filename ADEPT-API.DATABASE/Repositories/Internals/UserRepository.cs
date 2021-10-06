using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;

namespace ADEPT_API.Repositories.Internals
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(AdeptContext pContext) : base(pContext) { }
    }
}
