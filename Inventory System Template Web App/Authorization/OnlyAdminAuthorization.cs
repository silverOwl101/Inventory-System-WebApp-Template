using Microsoft.AspNetCore.Authorization;

namespace Inventory_System_Template_Web_App.Authorization
{
    public class OnlyAdminAuthorization : AuthorizationHandler<OnlyAdminAuthorization>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       OnlyAdminAuthorization requirement)
        {
            if (context.User.IsInRole("admin"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
