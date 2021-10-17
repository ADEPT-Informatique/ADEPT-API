using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Middleware
{
    public class AuthenticationMiddleWare
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthRepository authRepository)
        {
            //On trouve le User à partir du UserId de Firebase

            ClaimsPrincipal user = context.User;
            string id = user.Claims.FirstOrDefault(x => x.Type.ToUpper() == "USER_ID")?.Value;

            User authenticatedUser = await authRepository.GetFirstOrDefaultAsync(x => x.FireBaseID == id);
            context.Items["User"] = authenticatedUser;

            await _next(context);
        }
    }
}
