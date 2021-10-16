using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.DATACONTRACTS.Dto.Users.Authentification
{
    public class AuthenticateInDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
