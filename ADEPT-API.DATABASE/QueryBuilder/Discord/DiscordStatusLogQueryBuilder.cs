using ADEPT_API.DATABASE.Models.Discord;
using ADEPT_API.DATABASE.QueryBuilder.Abstracts;
using ADEPT_API.DATACONTRACTS.Dto.Discord;
using ADEPT_API.DATACONTRACTS.Dto.Discord.Operations.Queries;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.QueryBuilder.Discord
{
    public class DiscordStatusLogQueryBuilder : QueryBuilder<DiscordStatusLog>
    {
        public DiscordStatusLogQueryBuilder(string pSearches) : base(pSearches) { }

        public override Expression<Func<DiscordStatusLog, bool>> GetQuery<TQueryDto>(TQueryDto queryDto)
        {
            if (queryDto is { } && queryDto is DiscordStatusLogQueryRequestDto applicationQueryDto)
            {
                //Query AffectedIds
                if (applicationQueryDto.AffectedIds is { } && applicationQueryDto.AffectedIds.Any())
                {
                    Expression<Func<DiscordStatusLog, bool>> queryIds = entity => applicationQueryDto.AffectedIds.Contains(entity.AffectedUserId);
                    _query = _query is null ? queryIds : _query.And(queryIds);
                }

                //Query CreatedByIds
                if (applicationQueryDto.CreatedByIds is { } && applicationQueryDto.CreatedByIds.Any())
                {
                    Expression<Func<DiscordStatusLog, bool>> queryUserIds = entity => applicationQueryDto.CreatedByIds.Contains(entity.CreatedByUserId);
                    _query = _query is null ? queryUserIds : _query.And(queryUserIds);
                }

                //Query Types
                if (applicationQueryDto.Types is { } && applicationQueryDto.Types.Any())
                {
                    Expression<Func<DiscordStatusLog, bool>> queryReviewerUserIds = entity => applicationQueryDto.Types.Contains(entity.Type);
                    _query = _query is null ? queryReviewerUserIds : _query.And(queryReviewerUserIds);
                }

                //Query RevertedStates
                if (applicationQueryDto.IsReverted.HasValue)
                {
                    if (applicationQueryDto.IsReverted.Value)
                    {
                        Expression<Func<DiscordStatusLog, bool>> queryApplicationStates = entity => entity.ReservionLogId.HasValue;
                        _query = _query is null ? queryApplicationStates : _query.And(queryApplicationStates);
                    }
                    else
                    {
                        Expression<Func<DiscordStatusLog, bool>> queryApplicationStates = entity => !entity.ReservionLogId.HasValue;
                        _query = _query is null ? queryApplicationStates : _query.And(queryApplicationStates);
                    }
                }
            }

            return _query ??= entity => true;
        }
    }
}
