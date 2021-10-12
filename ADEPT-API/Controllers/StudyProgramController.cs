using ADEPT_API.Exceptions;
using ADEPT_API.LIBRARY.Dto.Users;
using ADEPT_API.LIBRARY.Exceptions.Interface;
using ADEPT_API.LIBRARY.Services;
using Microsoft.AspNetCore.Authorization;
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
        public StudyProgramController(IStudyProgramService pStudyProgramService)
        {
            _studyProgramService = pStudyProgramService;
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
        [HttpGet("{id}/deletionimpact")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> GetDeletionImpact([FromRoute] Guid id)
        {
            var response = _studyProgramService.DeletionImpactAsync(id);
            return Ok(response);
        }
    }
}
