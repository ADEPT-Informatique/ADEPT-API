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
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(_studyProgramService.GetAll());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("{id}/deletionimpact")]
        public async Task<IActionResult> GetDeletionImpact([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
