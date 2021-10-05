using ADEPT_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Services.IService
{
    public interface IUserService
    {
        User CreateUser(string pFirebaseId, string pUsername, string pEmail);
    }
}
