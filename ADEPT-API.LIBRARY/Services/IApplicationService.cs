using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="applicationCreateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationDto> CreateApplicationAsync(Guid userId, ApplicationCreateRequestDto applicationCreateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="applicationsQueryDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PaginatedCollectionResultDto<ApplicationDto>> GetApplicationsByPageByQueryAsync(int pageIndex, int pageSize, ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationsQueryDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ApplicationDto>> GetApplicationsByQueryAsync(ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="userId"></param>
        /// <param name="applicationUpdateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, Guid userId, ApplicationUpdateRequestDto applicationUpdateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="reviewedByUserId"></param>
        /// <param name="applicationUpdateStateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationDto> UpdateApplicationStateAsync(Guid applicationId, Guid reviewedByUserId, ApplicationUpdateStateRequestDto applicationUpdateStateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationDto> CancelApplicationAsync(Guid applicationId, Guid userId, CancellationToken cancellationToken);
    }
}