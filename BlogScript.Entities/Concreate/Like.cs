using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concreate
{
    public class Like:EntityBase,ILike
    {
        public int Blogid { get; set; }
        public int Userid { get; set; }
        public bool IsLike { get; set; }
    }
}
