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
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationDto> GetApplicationByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="pApplicationsQueryDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PaginatedCollectionResultDto<ApplicationDto>> GetApplicationsByPageByQuery(int pageIndex, int pageSize, ApplicationsQueryDto pApplicationsQueryDto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pApplicationsQueryDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ApplicationDto>> GetApplicationsByQuery(ApplicationsQueryDto pApplicationsQueryDto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryable"></param>
        /// <returns></returns>
        IQueryable<Application> IncludeAll(IQueryable<Application> queryable);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="applicationUpdateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationDto> UpdateApplicationAsync(Guid applicationId, ApplicationUpdateRequestDto applicationUpdateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="reviewedByUserId"></param>
        /// <param name="applicationUpdateStateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationDto> UpdateApplicationStateAsync(Guid applicationId, ApplicationUpdateStateRequestDto applicationUpdateStateRequestDto, CancellationToken cancellationToken, Guid? reviewedByUserId = null);
    }
}