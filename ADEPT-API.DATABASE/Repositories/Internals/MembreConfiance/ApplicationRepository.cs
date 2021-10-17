using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.QueryBuilder;
using ADEPT_API.DATABASE.Repositoriese;
using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests;
using ADEPT_API.DATACONTRACTS.Dto.Users.Enums;
using ADEPT_API.DATACONTRACTS.Models.MembreConfiance.Enums;
using ADEPT_API.Repositories.Internals;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.Repositories.Internals.MembreConfiance
{
    internal class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        private readonly IMapper _mapper;

        public ApplicationRepository(AdeptContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException($"{nameof(ApplicationRepository)} was expection a value for {nameof(mapper)} but received null..");
        }

        public async Task<ApplicationDto> GetApplicationByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var application = await base.GetFirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Application, ApplicationDto>(application);
        }

        public async Task<IEnumerable<ApplicationDto>> GetApplicationsByQueryAsync(ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new List<ApplicationDto>();

            var expression = this.GetApplicationSearchQuery(applicationsQueryDto);
            var applications = await base.GetAllAsync(expression, includeResolver: this.IncludeAll);
            if (applications is { } && applications.Any())
            {
                results.AddRange(applications.Select(x => _mapper.Map<Application, ApplicationDto>(x)));
            }

            return results;
        }

        public async Task<PaginatedCollectionResultDto<ApplicationDto>> GetApplicationsByPageByQueryAsync(int pageIndex, int pageSize, ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new PaginatedCollectionResultDto<ApplicationDto>();

            var expression = this.GetApplicationSearchQuery(applicationsQueryDto);
            var paginatedResults = await base.GetPaginatedResultsAsync(pageIndex, pageSize, expression, includeResolver: this.IncludeAll);
            if (paginatedResults is { } && paginatedResults.Any())
            {
                _mapper.Map<PagedList<IQueryable<Application>, Application>, PaginatedCollectionResultDto<ApplicationDto>>(paginatedResults, results);
            }

            return results;
        }

        public async Task<ApplicationDto> CreateApplicationAsync(Guid userId, ApplicationCreateRequestDto applicationCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var applicationToCreate = _mapper.Map<ApplicationCreateRequestDto, Application>(applicationCreateRequestDto);
            applicationToCreate.UserId = userId;

            await base.AddAsync(applicationToCreate);
            await base.SaveAsync();

            return _mapper.Map<Application, ApplicationDto>(applicationToCreate);
        }

        public async Task<ApplicationDto> UpdateApplicationStateAsync(Guid applicationId, ApplicationUpdateStateRequestDto applicationUpdateStateRequestDto, CancellationToken cancellationToken, Guid? reviewedByUserId = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var application = await base.GetAsync(applicationId);
            _mapper.Map<ApplicationUpdateStateRequestDto, Application>(applicationUpdateStateRequestDto, application);
            application.ReviewerUserId = reviewedByUserId;

            if (application.State == ApplicationStates.Accepted && !application.User.Roles.Any(x => x.Role == Roles.MembreConfiance))
            {
                application.User.Roles.Add(new UserRole { Role = Roles.MembreConfiance });
            }

            await base.SaveAsync();

            return _mapper.Map<Application, ApplicationDto>(application);
        }

        public async Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateRequestDto applicationUpdateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var application = await base.GetAsync(applicationId);
            _mapper.Map<ApplicationUpdateRequestDto, Application>(applicationUpdateRequestDto, application);

            await base.SaveAsync();

            return _mapper.Map<Application, ApplicationDto>(application);
        }

        #region Helpers

        private IQueryable<Application> IncludeAll(IQueryable<Application> queryable)
        {
            var query = queryable.Include(x => x.ApplicationQuestions)
                                 .Include(x => x.User).ThenInclude(x => x.Roles)
                                 .Include(x => x.Reviewer);

            return query;
        }

        private Expression<Func<Application, bool>> GetApplicationSearchQuery(ApplicationsQueryDto applicationsQueryDto)
        {
            var queryBuilder = new ApplicationQueryBuilder(null);
            var query = queryBuilder.GetQuery(applicationsQueryDto ??= new ApplicationsQueryDto());
            return query;
        }

        #endregion
    }
}
