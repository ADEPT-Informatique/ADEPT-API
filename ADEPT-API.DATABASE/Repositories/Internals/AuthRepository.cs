using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;

namespace ADEPT_API.Repositories.Internals
{
    internal class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        public AuthRepository(AdeptContext pContext) : base(pContext) { }
    }
}
