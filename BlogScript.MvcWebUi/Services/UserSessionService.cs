using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogScript.MvcWebUi.ExtensionMethods;
using BlogScript.Entities.Concreate;
using BlogScript.Bll.Concreate;

namespace BlogScript.MvcWebUi.Services
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserSessionService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }


        public SessionUser Get(string key)
        {
            return httpContextAccessor.HttpContext.Session.GetObj<SessionUser>(key);
        }

        public void Set(SessionUser value, string key)
        {
            httpContextAccessor.HttpContext.Session.SetObj(key, value);
        }
    }
}
