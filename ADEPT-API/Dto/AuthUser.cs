﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Dto
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
