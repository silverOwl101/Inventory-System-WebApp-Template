using Microsoft.AspNetCore.Authorization;

namespace Inventory_System_Template_Web_App.Authorization
{
    public class OnlyUserAuthorization : AuthorizationHandler<OnlyUserAuthorization>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       OnlyUserAuthorization requirement)
        {
            if (context.User.IsInRole("user"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
