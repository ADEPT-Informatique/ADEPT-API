using ADEPT_API.LIBRARY.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Queries;
using System.Threading;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests;
using System.Net;
using ADEPT_API.DATACONTRACTS.Dto;

namespace ADEPT_API.Controllers.MembreConfiance
{
    [Route("api/membreconfiance/applications")]
    [ApiController]
    public class ApplicationsController : ApiController
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService ?? throw new ArgumentNullException($"{nameof(QuestionsController)} was expection a value for {nameof(applicationService)} but received null..");
        }

        [HttpPost("query")]
        [ProducesResponseType(typeof(IEnumerable<ApplicationDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetApplicationsByQuery([FromBody] ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var respone = await _applicationService.GetApplicationsByQueryAsync(applicationsQueryDto, cancellationToken);
            return Ok(respone);
        }

        [HttpPost("pages/{pageIndex}/query")]
        [ProducesResponseType(typeof(PaginatedCollectionResultDto<ApplicationDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetApplicationByPageByQuery([FromRoute] int pageIndex, [FromQuery] int pageSize, [FromRoute] ApplicationsQueryDto applicationsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (pageIndex <= default(int) || pageSize <= default(int))
            {
                return BadRequest($"Les paramètres pageIndex : {pageIndex} et pageSize : {pageSize} doivent être plus grand que 0");
            }

            var response = await _applicationService.GetApplicationsByPageByQueryAsync(pageIndex, pageSize, applicationsQueryDto, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApplicationDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateApplication([FromBody] ApplicationCreateRequestDto applicationCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = await _applicationService.CreateApplicationAsync(base.AuthentificatedUserId, applicationCreateRequestDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApplicationDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateApplication([FromRoute] Guid id, [FromBody] ApplicationUpdateRequestDto applicationUpdateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = await _applicationService.UpdateApplicationAsync(id, base.AuthentificatedUserId, applicationUpdateRequestDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}/cancel")]
        [ProducesResponseType(typeof(ApplicationDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CancelApplication([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = await _applicationService.CancelApplicationAsync(id, base.AuthentificatedUserId, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}/changestate")]
        [ProducesResponseType(typeof(ApplicationDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateApplicationState([FromRoute] Guid id, [FromBody] ApplicationUpdateStateRequestDto applicationUpdateStateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = await _applicationService.UpdateApplicationStateAsync(id, base.AuthentificatedUserId, applicationUpdateStateRequestDto, cancellationToken);
            return Ok(response);
        }
    }
}
