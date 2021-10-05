using ADEPT_API.Context;
using ADEPT_API.Models;
using ADEPT_API.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Repositories.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository 
    {
        private readonly AdeptContext _context;

        public UserRepository(AdeptContext pContext) : base(pContext)
        {
            _context = pContext;
        }
    }
}
