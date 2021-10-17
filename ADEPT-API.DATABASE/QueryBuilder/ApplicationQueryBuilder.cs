using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Queries;
using ADEPT_API.DATABASE.QueryBuilder.Abstracts;
using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ADEPT_API.DATABASE.QueryBuilder
{
    public class ApplicationQueryBuilder : QueryBuilder<Application>
    {
        public ApplicationQueryBuilder(string pSearches) : base(pSearches) { }

        public override Expression<Func<Application, bool>> GetQuery<TQueryDto>(TQueryDto queryDto)
        {
            if (queryDto is ApplicationsQueryDto applicationQueryDto)
            {
                //Query Ids
                Expression<Func<Application, bool>> queryIds = entity => applicationQueryDto.Ids.Contains(entity.Id);
                _query = applicationQueryDto.Ids is null || !applicationQueryDto.Ids.Any() ? _query : _query is null ? queryIds : _query.And(queryIds);

                //Query UserIds
                Expression<Func<Application, bool>> queryUserIds = entity => applicationQueryDto.UserIds.Contains(entity.UserId);
                _query = applicationQueryDto.UserIds is null || !applicationQueryDto.UserIds.Any() ? _query : _query is null ? queryUserIds : _query.And(queryUserIds);

                //Query ReviewerUserIds
                Expression<Func<Application, bool>> queryReviewerUserIds = entity => applicationQueryDto.ReviewerUserIds.Contains(entity.ReviewerUserId);
                _query = applicationQueryDto.ReviewerUserIds is null || !applicationQueryDto.ReviewerUserIds.Any() ? _query : _query is null ? queryReviewerUserIds : _query.And(queryReviewerUserIds);

                //Query ApplicationStates
                Expression<Func<Application, bool>> queryApplicationStates = entity => applicationQueryDto.States.Contains(entity.State);
                _query = applicationQueryDto.States is null || !applicationQueryDto.States.Any() ? _query : _query is null ? queryApplicationStates : _query.And(queryApplicationStates);
            }

            return _query ??= entity => true;
        }
    }
}
