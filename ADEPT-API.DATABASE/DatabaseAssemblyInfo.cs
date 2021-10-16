using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ADEPT_API.DATABASE
{
    public delegate IQueryable<TEntity> IncludeResolver<TEntity>(IQueryable<TEntity> queryableEntity) where TEntity : class;

    public static class DatabaseAssemblyInfo
    {

    }
}
