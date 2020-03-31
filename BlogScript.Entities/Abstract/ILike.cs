using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Abstract
{
    public interface ILike
    {
         int Blogid { get; set; }
         int Userid { get; set; }
         bool IsLike { get; set; }
    }
}
