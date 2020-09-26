using CloadBerry.Attributes;
using CloadBerry.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloadBerry.Filters
{
    public class AuthorizationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                         ActionExecutionDelegate next)
        {
            if (context.ActionDescriptor
                 .FilterDescriptors
                 .Any(x => x.Filter is SkipAuthAttribute))
            {
                await next();
                return;
            }

            var userService = (UserService)context.HttpContext.RequestServices.GetService(typeof(UserService));
            var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader != null)
            {
                var currentUser = userService.ValidateToken(authHeader);

                if (currentUser != null)
                {
                    await next();
                    return;
                }
            }

            context.HttpContext.Response.StatusCode = 401;
        }
    }
}
