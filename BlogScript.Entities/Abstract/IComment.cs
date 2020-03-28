using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Abstract
{
    public interface IComment
    {
        int? Userid { get; set; }
        User User { get; set; }


        int Blogid { get; set; }
        Blog Blog { get; set; }


        int Points { get; set; }

        string Content { get; set; }
    }
}
