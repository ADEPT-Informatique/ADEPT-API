﻿using System;

namespace ADEPT_API.Dto.Errors
{
    public class Error
    {
        public string ErrorCode {  get; set; }

        public string Message {  get; set; }

        public string Stacktrace {  get; set; }
    }
}
