using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using BlogScript.MvcWebUi.ExtensionMethods;
using BlogScript.Entities.Concreate;
using BlogScript.Bll.Concreate;

namespace BlogScript.MvcWebUi.Services
{
    public class UserCookieService : IUserCookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserCookieService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public SessionUser Get(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies.Get<SessionUser>(key);
        }


        public void Set(string key, object value, int? expireTime)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Set(key, value, expireTime);
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Remove(key);
        }
    }
}
