using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Abstract
{
    public interface ICategory
    {
        string Name { get; set; }
        int ParentID { get; set; }
    }
}
