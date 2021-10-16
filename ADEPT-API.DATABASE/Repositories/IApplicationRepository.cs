using ADEPT_API.DATABASE.Models.MembreConfiance;
using System.Linq;

namespace ADEPT_API.DATABASE.Repositories
{
    public interface IApplicationRepository : IBaseRepository<Application>
    {
        IQueryable<Application> IncludeAll(IQueryable<Application> queryable);
    }
}
