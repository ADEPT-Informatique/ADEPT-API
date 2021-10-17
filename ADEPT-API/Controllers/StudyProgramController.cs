using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.LIBRARY.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<StudyProgramDto>), 200)]
        public async Task<IActionResult> Get()
        {
            var response = _studyProgramService.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        //[Authorize]
        [ProducesResponseType(typeof(StudyProgramDto), 200)]
        public async Task<IActionResult> Post([FromBody] StudyProgramCreateRequestDto body)
        {
            var response = _studyProgramService.CreateAsync(body);
            return Ok(response);
        }

        //[Authorize]
        [HttpGet("{pId}/deletionimpact")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> GetDeletionImpact([FromRoute] Guid pId)
        {
            var response = _studyProgramService.DeletionImpactAsync(pId);
            return Ok(response);
        }
    }
}
