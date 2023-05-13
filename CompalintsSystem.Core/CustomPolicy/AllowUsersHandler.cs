using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Identity.CustomPolicy
{
    public class AllowUsersHandler : AuthorizationHandler<AllowUserPolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AllowUserPolicy requirement)
        {
            if (requirement.AllowUsers.Any(user => user.Equals(context.User.Identity.Name, StringComparison.OrdinalIgnoreCase)))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
