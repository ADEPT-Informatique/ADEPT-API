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

        //TODO-OG Uncomment DiscordController when we will start the implementation => SonarCloud don't like that there's no Await in each method
        //[HttpGet]
        //public async Task<IActionResult> GetMutedUsers()
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpGet("{pId}")]
        //public async Task<IActionResult> GetMutedUserById()
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateUserMute()
        //{
        //    throw new NotImplementedException();
        //}


        //[HttpPost("{id}")]

        //public async Task<IActionResult> UnmuteUser([FromRoute] Guid id, [FromQuery] string reason)
        //{            
        //    throw new NotImplementedException();
        //}
    }
}
