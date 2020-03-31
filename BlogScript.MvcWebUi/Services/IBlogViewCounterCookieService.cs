using BlogScript.MvcWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.MvcWebUi.Services
{
    public interface IBlogViewCounterCookieService
    {
        void Set(string key, BlogViewCounterModel value, int? expireTime);
        BlogViewCounterModel Get(string key);
        void Remove(string key);
    }
}
