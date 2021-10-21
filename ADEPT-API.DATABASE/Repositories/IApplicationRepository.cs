using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.Repositoriese
{
    public interface IApplicationRepository
    {
        /// <summary>
        /// Create a application for membre de confiance for a specific user
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="applicationCreateRequestDto">The application create request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<ApplicationDto> CreateApplicationAsync(Guid userId, ApplicationCreateRequestDto applicationCreateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// Obatin a specific application
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<ApplicationDto> GetApplicationByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain paginated applications depending on the query request
        /// </summary>
        /// <param name="pageIndex">The page index</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="applicationsQueryDto">The query request</param>
        /// <returns></returns>
        Task<PaginatedCollectionResultDto<ApplicationDto>> GetApplicationsByPageByQueryAsync(int pageIndex, int pageSize, ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain applications depending on the query request
        /// </summary>
        /// <param name="applicationsQueryDto">The query request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<IEnumerable<ApplicationDto>> GetApplicationsByQueryAsync(ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken);

        /// <summary>
        /// Update a specific application
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="applicationUpdateRequestDto">The update request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateRequestDto applicationUpdateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// Update the state of a specific application
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="applicationUpdateStateRequestDto">The state update request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <param name="reviewedByUserId">The reviewer user id (default = null)</param>
        /// <returns></returns>
        Task<ApplicationDto> UpdateApplicationStateAsync(Guid applicationId, ApplicationUpdateStateRequestDto applicationUpdateStateRequestDto, CancellationToken cancellationToken, Guid? reviewedByUserId = null);
    }
}