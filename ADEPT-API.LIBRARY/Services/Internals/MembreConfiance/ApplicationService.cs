using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATABASE.Repositoriese;
using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests;
using ADEPT_API.DATACONTRACTS.Models.MembreConfiance.Enums;
using ADEPT_API.Exceptions;
using ADEPT_API.LIBRARY.Exceptions;
using ADEPT_API.LIBRARY.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services.Internals.MembreConfiance
{
    internal class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository ?? throw new ArgumentNullException(nameof(applicationRepository), $"{nameof(ApplicationService)} was expection a value for {nameof(applicationRepository)} but received null..");
        }

        public async Task<IEnumerable<ApplicationDto>> GetApplicationsByQueryAsync(ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var results = await _applicationRepository.GetApplicationsByQueryAsync(applicationsQueryDto, cancellationToken);
            return results;
        }

        public async Task<PaginatedCollectionResultDto<ApplicationDto>> GetApplicationsByPageByQueryAsync(int pageIndex, int pageSize, ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var results = await _applicationRepository.GetApplicationsByPageByQueryAsync(pageIndex, pageSize, applicationsQueryDto, cancellationToken);
            return results;
        }

        public async Task<ApplicationDto> CreateApplicationAsync(Guid userId, ApplicationCreateRequestDto applicationCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var applicationQuery = new ApplicationsQueryDto { UserIds = new List<Guid> { userId }, CreatedTimestampUtcQuery = EpochUtility.ObtainTimestampQueryForApplicationCreation() };
            var applications = await _applicationRepository.GetApplicationsByQueryAsync(applicationQuery, cancellationToken);
            if (applications is { } && applications.Any())
            {
                throw new AlreadyAppliedException(nameof(Application).ToUpper(), $"Vous avez déjà appliquer durant cette session veuillez essayé la session prochaine.");
            }

            var result = await _applicationRepository.CreateApplicationAsync(userId, applicationCreateRequestDto, cancellationToken);
            return result;
        }

        public async Task<ApplicationDto> CancelApplicationAsync(Guid applicationId, Guid userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var application = (await _applicationRepository.GetApplicationByIdAsync(applicationId, cancellationToken)) ?? throw new NotFoundException(nameof(Application).ToUpper(), $"L'application {applicationId} est introuvable.");
            if (application.User.Id != userId)
            {
                throw new UnAuthorizedException(nameof(application).ToUpper(), $"Vous n'avez pas le droit de modifier l'application {applicationId}");
            }

            var result = await _applicationRepository.UpdateApplicationStateAsync(applicationId, new ApplicationUpdateStateRequestDto { State = ApplicationStates.Cancelled }, cancellationToken);
            return result;
        }

        public async Task<ApplicationDto> UpdateApplicationStateAsync(Guid applicationId, Guid reviewedByUserId, ApplicationUpdateStateRequestDto applicationUpdateStateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _ = await _applicationRepository.GetApplicationByIdAsync(applicationId, cancellationToken) ?? throw new NotFoundException(nameof(Application).ToUpper(), $"L'application {applicationId} est introuvable.");

            var result = await _applicationRepository.UpdateApplicationStateAsync(applicationId, applicationUpdateStateRequestDto, cancellationToken, reviewedByUserId);
            return result;
        }

        public async Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, Guid userId, ApplicationUpdateRequestDto applicationUpdateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var application = (await _applicationRepository.GetApplicationByIdAsync(applicationId, cancellationToken)) ?? throw new NotFoundException(nameof(Application).ToUpper(), $"L'application {applicationId} est introuvable.");
            if (application.User.Id != userId)
            {
                throw new UnAuthorizedException(nameof(application).ToUpper(), $"Vous n'avez pas le droit de modifier l'application {applicationId}");
            }

            var result = await _applicationRepository.UpdateApplicationAsync(applicationId, applicationUpdateRequestDto, cancellationToken);
            return result;
        }
    }
}
