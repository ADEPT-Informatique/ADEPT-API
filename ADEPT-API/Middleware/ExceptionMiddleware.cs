﻿using ADEPT_API.Dto.Errors;
using ADEPT_API.Exceptions.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ADEPT_API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _request;

        public ExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception exception)
            {
                var contextResponse = context.Response;
                contextResponse.ContentType = "application/json";

                var error = new Error();
                if (exception is AdeptException adeptException)
                {
                    contextResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    error = new Error { ErrorCode = adeptException.ErrorCode, Message = adeptException.Message };
                }
                else
                {
                    contextResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    error = new Error { ErrorCode = "UnHandledError", Message = exception?.Message, Stacktrace = exception?.StackTrace };
                }

                await contextResponse.WriteAsync(JsonConvert.SerializeObject(error));
            }
        }
    }
}
