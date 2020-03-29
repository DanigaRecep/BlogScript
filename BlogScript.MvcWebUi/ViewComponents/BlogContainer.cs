using BlogScript.Entities.Concreate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.MvcWebUi.ViewComponents
{
    public class BlogContainer:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Blog blog)
        {
            return View(blog);
        }
    }
}
