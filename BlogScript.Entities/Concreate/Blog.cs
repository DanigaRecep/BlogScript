using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concreate
{
    public class Blog:EntityBase,IBlog
    {

        public int Categoryid { get; set; }
        public Category Category { get; set; }

        public int Userid { get; set; }
        public User User { get; set; }

        public string Title { get; set; }

        public int ViewCount { get; set; }
        public int Points { get; set; }
        public string Tags { get; set; }

        public string Content { get; set; }

        public bool Privacy { get; set; }


        public ICollection<Comment>  Comments { get; set; }
    }
}
