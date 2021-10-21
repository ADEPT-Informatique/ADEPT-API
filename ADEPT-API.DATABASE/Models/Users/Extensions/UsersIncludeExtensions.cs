using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ADEPT_API.DATABASE.Models.Users.Extensions
{
    internal static class UsersIncludeExtensions
    {
        public static IQueryable<User> IncludeAll(IQueryable<User> queryable)
        {
            queryable = queryable.Include(x => x.Roles)
                                 .Include(x => x.Program);

            return queryable;
        }
    }
}
