using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Queries;
using ADEPT_API.DATABASE.QueryBuilder.Abstracts;
using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ADEPT_API.DATABASE.QueryBuilder
{
    public class QuestionQueryBuilder : QueryBuilder<Question>
    {
        public QuestionQueryBuilder(string pSearches) : base(pSearches) { }

        public override Expression<Func<Question, bool>> GetQuery<TQueryDto>(TQueryDto queryDto)
        {
            if (queryDto is QuestionsQueryDto questionsQueryDto)
            {
                //Query Ids
                Expression<Func<Question, bool>> queryIds = entity => questionsQueryDto.Ids.Contains(entity.Id);
                _query = questionsQueryDto.Ids is null || !questionsQueryDto.Ids.Any() ? _query : _query is null ? queryIds : _query.And(queryIds);

                //Query IsActivated
                if (questionsQueryDto.IsActivated.HasValue)
                {
                    Expression<Func<Question, bool>> queryIsActivated = entity => entity.Activated == questionsQueryDto.IsActivated.Value;
                    _query = _query is null ? queryIsActivated : _query.And(queryIsActivated);
                }

                //Apply Searches
                if (_searches.Any())
                {
                    Expression<Func<Question, bool>> searches = entity => _searches.Any(x => entity.Content.ToLower().Contains(x));
                    _query = _query is null ? searches : _query.And(searches);
                }
            }

            return _query ??= entity => true;
        }
    }
}
