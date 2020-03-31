using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.MvcWebUi.Models
{
    public class BlogViewCounterModel
    {
        public int Blogid { get; set; }
        public bool IsLogin { get; set; }
        public int Userid { get; set; }
    }
}
