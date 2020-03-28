using BlogScript.Bll.Concreate;
using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.MvcWebUi.Services
{
    public interface IUserCookieService
    {
        void Set(string key, object value, int? expireTime);
        SessionUser Get(string key);
        void Remove(string key);
    }
}
