using BlogScript.MvcWebUi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogScript.MvcWebUi.ExtensionMethods;

namespace BlogScript.MvcWebUi.Services
{
    public class BlogViewCounterCookieService: IBlogViewCounterCookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlogViewCounterCookieService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public BlogViewCounterModel Get(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies.Get<BlogViewCounterModel>(key);
        }


        public void Set(string key, BlogViewCounterModel value, int? expireTime)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Set(key, value, expireTime);
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Remove(key);
        }
    }
}
