using ADEPT_API.Models;
using ADEPT_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Controllers
{
    public class ApiController : ControllerBase
    {
        public User CurrentUser {
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
