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
        public async Task<IActionResult> GetMutedUsers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMutedUserById()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserMute()
        {
            throw new NotImplementedException();
        }


        [HttpPost("{id}")]

        public async Task<IActionResult> UnmuteUser([FromRoute] Guid id, [FromQuery] string reason)
        {
            throw new NotImplementedException();
        }
    }
}
