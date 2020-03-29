using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;
using BlogScript.Bll.Helpers;
namespace BlogScript.Bll.Concreate
{
    public class SessionUser : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ProfilePhoto { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
