using BlogScript.Bll.Concreate;
using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.MvcWebUi.Services
{
    public interface IUserSessionService
    {
        SessionUser Get(string key);
        void Set(SessionUser value, string key);
    }
}
