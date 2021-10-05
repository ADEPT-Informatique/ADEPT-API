using ADEPT_API.Models;
using ADEPT_API.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADEPT_API.Middleware
{
    public class AuthenticationMiddleWare
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext pContext, IAuthRepository authRepository)
        {
            //On trouve le User à partir du UserId de Firebase

            ClaimsPrincipal user = pContext.User;
            string id = user.Claims.FirstOrDefault(x => x.Type.ToUpper() == "USER_ID")?.Value;

            User authenticatedUser = authRepository.GetFirstOrDefault(x => x.FireBaseID == id);
            pContext.Items["User"] = authenticatedUser;

            await _next(pContext);
        }
    }
}
