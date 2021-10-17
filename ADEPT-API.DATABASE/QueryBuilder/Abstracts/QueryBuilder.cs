using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ADEPT_API.DATABASE.QueryBuilder.Abstracts
{
    public abstract class QueryBuilder<TSourceEntity>
    {
        protected Expression<Func<TSourceEntity, bool>> _query;

        protected IEnumerable<string> _searches;

        public QueryBuilder(string pSearches)
        {
            _query = default(Expression<Func<TSourceEntity, bool>>);
            _searches = !string.IsNullOrWhiteSpace(pSearches) ? pSearches.ToLower().Split(',', StringSplitOptions.RemoveEmptyEntries) : new List<string>();
        }
        
        public abstract Expression<Func<TSourceEntity, bool>> GetQuery<TQueryDto>(TQueryDto queryDto) where TQueryDto : class;
    }
}
