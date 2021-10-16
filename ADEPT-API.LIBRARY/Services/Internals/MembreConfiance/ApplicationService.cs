using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.LIBRARY.QueryBuilder;
using System.Linq;
using Sakura.AspNetCore;
using ADEPT_API.Exceptions;

namespace ADEPT_API.LIBRARY.Services.Internals.MembreConfiance
{
    internal class ApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository ?? throw new ArgumentNullException($"{nameof(ApplicationService)} was expection a value for {nameof(applicationRepository)} but received null..");
            _mapper = mapper ?? throw new ArgumentNullException($"{nameof(ApplicationService)} was expection a value for {nameof(mapper)} but received null..");
        }

        public async Task<IEnumerable<ApplicationDto>> GetApplicationsByQuery(ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new List<ApplicationDto>();

            var expression = this.GetApplicationSearchQuery(applicationsQueryDto);
            var applications = await _applicationRepository.GetAllAsync(expression, includeResolver: _applicationRepository.IncludeAll);
            if (applications is { } && applications.Any())
            {
                results.AddRange(applications.Select(x => _mapper.Map<Application, ApplicationDto>(x)));
            }

            return results;
        }

        public async Task<PaginatedCollectionResultDto<ApplicationDto>> GetApplicationsByPageByQuery(int pageIndex, int pageSize, ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new PaginatedCollectionResultDto<ApplicationDto>();

            var expression = this.GetApplicationSearchQuery(applicationsQueryDto);
            var paginatedResults = await _applicationRepository.GetPaginatedResultsAsync(pageIndex, pageSize, expression, includeResolver: _applicationRepository.IncludeAll);
            if (paginatedResults is { } && paginatedResults.Any())
            {
                _mapper.Map<PagedList<IQueryable<Application>, Application>, PaginatedCollectionResultDto<ApplicationDto>>(paginatedResults, results);
            }

            return results;
        }

        public async Task<ApplicationDto> CreateApplicationAsync(Guid userId, ApplicationCreateRequestDto applicationCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            //TODO Get last Application

            var applicationToCreate = _mapper.Map< ApplicationCreateRequestDto, Application>(applicationCreateRequestDto);
            applicationToCreate.UserId = userId;

            throw new NotImplementedException();
        }

        public async Task<ApplicationDto> UpdateApplicationStateAsync(Guid applicationId, Guid reviewedByUserId, ApplicationUpdateStateRequestDto applicationUpdateStateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var application = (await _applicationRepository.GetAsync(applicationId)) ?? throw new NotFoundException(nameof(Application).ToUpper(), $"L'application {applicationId} est introuvable.");
            _mapper.Map<ApplicationUpdateStateRequestDto, Application>(applicationUpdateStateRequestDto, application);
            application.ReviewerUserId = reviewedByUserId;

            await _applicationRepository.SaveAsync();

            return _mapper.Map<Application, ApplicationDto>(application);
        }

        public async Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, Guid userId, ApplicationUpdateRequestDto applicationUpdateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var application = (await _applicationRepository.GetAsync(applicationId)) ?? throw new NotFoundException(nameof(Application).ToUpper(), $"L'application {applicationId} est introuvable.");

            if (application.UserId != userId)
            {

            }

            _mapper.Map<ApplicationUpdateRequestDto, Application>(applicationUpdateRequestDto, application);
            await _applicationRepository.SaveAsync();

            return _mapper.Map<Application, ApplicationDto>(application);
        }

        #region Helpers

        private Expression<Func<Application,bool>> GetApplicationSearchQuery(ApplicationsQueryDto applicationsQueryDto)
        {
            var queryBuilder = new ApplicationQueryBuilder(null);
            var query = queryBuilder.GetQuery(applicationsQueryDto ??= new ApplicationsQueryDto());
            return query;
        }

        #endregion
    }
}
