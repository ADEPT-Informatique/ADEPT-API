using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.Discord;
using ADEPT_API.DATABASE.QueryBuilder.Discord;
using ADEPT_API.DATACONTRACTS.Dto.Discord;
using ADEPT_API.DATACONTRACTS.Dto.Discord.Operations.Queries;
using ADEPT_API.Repositories.Internals;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.Repositories.Internals.Discord
{
    internal class DiscordStatusLogRepository : BaseRepository<DiscordStatusLog>
    {
        private readonly IMapper _mapper;
        public DiscordStatusLogRepository(AdeptContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), $"{nameof(DiscordStatusLogRepository)} was expection a value for {nameof(mapper)} but received null..");
        }


        public async Task<IEnumerable<DiscordStatusLogDto>> GetQuestionsByQueryAsync(DiscordStatusLogQueryRequestDto discordStatusLogQueryDto, CancellationToken cancellationToken, string searches = null)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new List<DiscordStatusLogDto>();

            var expression = GetDiscordStatusLogSearchQuery(discordStatusLogQueryDto, searches);
            var statusLogs = await base.GetAllAsync(expression);

            if (statusLogs is { } && statusLogs.Any())
            {
                results.AddRange(statusLogs.Select(x => _mapper.Map<DiscordStatusLog, DiscordStatusLogDto>(x)));
            }

            return results;
        }

        private static Expression<Func<DiscordStatusLog, bool>> GetDiscordStatusLogSearchQuery(DiscordStatusLogQueryRequestDto questionsQueryDto, string searches)
        {
            var queryBuilder = new DiscordStatusLogQueryBuilder(searches);
            var query = queryBuilder.GetQuery(questionsQueryDto);
            return query;
        }
    }
}
