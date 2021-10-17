using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.LIBRARY.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace ADEPT_API.Controllers
{
    [ApiController]
    [Route("api/studyprogram")]
    public class StudyProgramController : ControllerBase
    {
        private readonly IStudyProgramService _studyProgramService;
        public StudyProgramController(IStudyProgramService studyProgramService)
        {
            _studyProgramService = studyProgramService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudyProgramDto>), 200)]
        public async Task<IActionResult> GetPrograms(CancellationToken cancellationToken)
        {
            var response = await _studyProgramService.GetAllAsync(cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(StudyProgramDto), 200)]
        public async Task<IActionResult> CreateProgram([FromBody] StudyProgramCreateRequestDto studyProgramCreateRequestDto, CancellationToken cancellationToken)
        {
            var response = await _studyProgramService.CreateAsync(studyProgramCreateRequestDto, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}/deletionimpact")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> GetProgramDeletionImpact([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _studyProgramService.DeletionImpactAsync(id, cancellationToken);
            return Ok(response);
        }
    }
}
