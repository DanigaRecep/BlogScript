using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concreate
{
    public class Category:EntityBase,ICategory
    {
        public string Name { get; set; }
        public int ParentID { get; set; }
    }
}
