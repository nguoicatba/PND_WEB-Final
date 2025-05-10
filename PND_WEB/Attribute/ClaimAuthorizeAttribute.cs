using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PND_WEB.Controllers;
using System;
using System.Linq;
using System.Security.Claims;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class ClaimAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _claimType;
    private readonly string _claimValue;

    public ClaimAuthorizeAttribute(string claimType, string claimValue)
    {
        _claimType = claimType;
        _claimValue = claimValue;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        var hasClaim= user.Claims.Any(c=>c.Type ==  _claimType && c.Value == _claimValue);

        if (!hasClaim)
        {
            // Nếu không có quyền, trả về 403 Forbidden
            context.Result = new ForbidResult();
            // hi

        }





    }
}
