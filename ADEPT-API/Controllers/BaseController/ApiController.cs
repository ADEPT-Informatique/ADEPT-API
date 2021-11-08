using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ADEPT_API.Controllers
{
    public class ApiController : ControllerBase
    {
        public ApiController() { }

        public string AuthenticatedFirebaseId
        {
            get
            {
                try
                {
                    return this.HttpContext.User.Identities.First().Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
                }
                catch
                {

                    return string.Empty;
                }
            }
        }

        public Guid AuthenticatedUserId
        {
            get
            {
                try
                {
                   return Guid.Parse(this.HttpContext.User.Identities.First().Claims.FirstOrDefault(x => x.Type == "adeptUserId")?.Value);
                }
                catch 
                {
                    return Guid.Empty;
                }
            }
        }
    }
}
