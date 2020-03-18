using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concreate
{
    public class Comment:EntityBase,IComment
    {
        public int? Userid { get; set; }

        public int Blogid { get; set; }
        public Blog Blog { get; set; }


        public int Points { get; set; }

        public string Content { get; set; }
    }
}
