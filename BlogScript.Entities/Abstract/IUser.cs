using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Abstract
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string ProfilePhoto { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
        bool IsAdmin { get; set; }

        ICollection<Blog> Blogs { get; set; }
    }
}
