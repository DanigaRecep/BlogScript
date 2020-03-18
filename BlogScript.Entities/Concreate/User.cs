using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concreate
{
    public class User : EntityBase, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ProfilePhoto { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        /// <summary>
        ///  Admin:true
        ///  Standart:false
        /// </summary>
        public bool IsAdmin { get; set; } = false;

        public ICollection<Blog> Blogs { get; set; }

    }
}
