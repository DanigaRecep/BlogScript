using Microsoft.AspNetCore.Mvc.Filters;
using System;
using BlogScript.MvcWebUi.ExtensionMethods;
using BlogScript.Bll.Concreate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BlogScript.MvcWebUi.Attributes
{
    public class UserAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            SessionUser session = context.HttpContext.Session.GetObj<SessionUser>("LoginUser");
            if (session == null)
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "", controller = "Login", action = "Index" }));
        }
    }
}
