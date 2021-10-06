using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Dto.Users.Authentification
{
    public class SignInRequestDto
    {
        public string Token { get; set; }
        public bool ReturnSecureToken { get; set; }
    }

    public class WaduhekOut {

        public string IdToken { get; set; }
    
    }
}
