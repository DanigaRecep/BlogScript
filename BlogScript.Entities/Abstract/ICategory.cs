using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Abstract
{
    public interface ICategory
    {
        string Name { get; set; }
        int ParentID { get; set; }
        ICollection<Blog> Blogs { get; set; }

    }
}
