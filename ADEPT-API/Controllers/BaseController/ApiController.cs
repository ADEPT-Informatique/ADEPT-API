using ADEPT_API.DATABASE.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace ADEPT_API.Controllers
{
    public class ApiController : ControllerBase
    {
        public User CurrentUser
        {
            get
            {
                return (User)HttpContext.Items["User"];
            }
        }

        public ApiController()
        {
        }
    }
}
