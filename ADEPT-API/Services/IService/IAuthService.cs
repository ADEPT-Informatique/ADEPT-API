using ADEPT_API.Dto;
using ADEPT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Services
{
    public interface IAuthService
    {
        AuthUser Authenticate(string pToken);


    }
}
