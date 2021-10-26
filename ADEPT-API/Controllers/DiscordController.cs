using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ADEPT_API.Controllers
{
    [Route("api/discord")]
    [ApiController]
    public class DiscordController : ApiController
    {

        public DiscordController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetStatus()
        {
            throw new NotImplementedException();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromQuery] string reason)
        {
            throw new NotImplementedException();
        }
    }
}
