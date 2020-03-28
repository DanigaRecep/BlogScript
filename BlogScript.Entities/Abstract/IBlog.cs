using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Abstract
{
    public interface IBlog
    {

        int Categoryid { get; set; }
        Category Category { get; set; }

        int Userid { get; set; }
        User User { get; set; }

        int ViewCount { get; set; }
        int Points { get; set; }
        string Tags { get; set; }

        string Content { get; set; }
        string Description { get; set; }


        ICollection<Comment> Comments { get; set; }
    }
}
