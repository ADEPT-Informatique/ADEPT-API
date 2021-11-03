using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Security.Handlers
{
    public abstract class AttributeAuthorisationHandler<TRequirement, TAttribute> : AuthorizationHandler<TRequirement>
        where TRequirement : IAuthorizationRequirement
        where TAttribute : Attribute
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TRequirement requirement)
        {
            var attributes = new List<TAttribute>();

            if (context.Resource is DefaultHttpContext defaultHttpContext)
            {
                var endpoint = defaultHttpContext.GetEndpoint();
                if (endpoint is { })
                {
                    var controllerActionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();

                    if (controllerActionDescriptor != null)
                    {
                        attributes.AddRange(GetAttributes(controllerActionDescriptor.ControllerTypeInfo.UnderlyingSystemType));
                        attributes.AddRange(GetAttributes(controllerActionDescriptor.MethodInfo));
                    }
                }               
            }

            return HandleRequirementAsync(context, requirement, attributes);
        }

        private static IEnumerable<TAttribute> GetAttributes(MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes(typeof(TAttribute), false)
                              .Cast<TAttribute>();
        }

        protected abstract Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       TRequirement requirement,
                                                       IEnumerable<TAttribute> attributes);
    }
}
