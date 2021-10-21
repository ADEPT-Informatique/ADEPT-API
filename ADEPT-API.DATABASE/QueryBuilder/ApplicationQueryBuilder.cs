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
            if (queryDto is { } && queryDto is ApplicationsQueryDto applicationQueryDto)
            {
                //Query Ids
                if (applicationQueryDto.Ids is { } && applicationQueryDto.Ids.Any())
                {
                    Expression<Func<Application, bool>> queryIds = entity => applicationQueryDto.Ids.Contains(entity.Id);
                    _query = _query is null ? queryIds : _query.And(queryIds);
                }

                //Query UserIds
                if (applicationQueryDto.UserIds is { } && applicationQueryDto.UserIds.Any())
                {
                    Expression<Func<Application, bool>> queryUserIds = entity => applicationQueryDto.UserIds.Contains(entity.UserId);
                    _query = _query is null ? queryUserIds : _query.And(queryUserIds);
                }

                //Query ReviewerUserIds
                if (applicationQueryDto.ReviewerUserIds is { } && applicationQueryDto.ReviewerUserIds.Any())
                {
                    Expression<Func<Application, bool>> queryReviewerUserIds = entity => applicationQueryDto.ReviewerUserIds.Contains(entity.ReviewerUserId);
                    _query = _query is null ? queryReviewerUserIds : _query.And(queryReviewerUserIds);
                }

                //Query ApplicationStates
                if (applicationQueryDto.States is { } && applicationQueryDto.States.Any())
                {
                    Expression<Func<Application, bool>> queryApplicationStates = entity => applicationQueryDto.States.Contains(entity.State);
                    _query = _query is null ? queryApplicationStates : _query.And(queryApplicationStates);
                }
            }

            return _query ??= entity => true;
        }
    }
}
