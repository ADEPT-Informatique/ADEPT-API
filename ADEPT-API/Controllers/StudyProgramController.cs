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
            return Ok(_studyProgramService.GetAll());
        }

        [HttpPost]
        //[Authorize]
        [ProducesResponseType(typeof(StudyProgramDto), 200)]
        public async Task<IActionResult> Post([FromBody] StudyProgramCreateRequestDto body)
        {
            return Ok(_studyProgramService.Create(body));
        }

        //[Authorize]
        [HttpGet("{id}/deletionimpact")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> GetDeletionImpact([FromRoute] Guid id)
        {
            return Ok(_studyProgramService.DeletionImpact(id));
        }
    }
}
