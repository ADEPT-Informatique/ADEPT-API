using ADEPT_API.DATABASE.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ADEPT_API.Controllers
{
    public class ApiController : ControllerBase
    {
        public ApiController() { }

        public User CurrentUser
        {
            get
            {
                return (User)HttpContext.Items["User"];
            }
        }

        public Guid AuthentificatedUserId
        {
            get
            {
                try
                {
                    //TODO-OG Add Logic to fetch userId from Token / Claims
                    return Guid.Empty;
                }
                catch
                {

                   return Guid.Empty;
                }
            }
        }
    }
}
