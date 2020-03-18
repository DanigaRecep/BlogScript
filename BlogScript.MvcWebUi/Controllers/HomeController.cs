using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogScript.MvcWebUi.Models;
using BlogScript.Bll.Abstract;
using BlogScript.Entities.Concreate;

namespace BlogScript.MvcWebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IBlogService blogService;

        public HomeController(IUserService userService,IBlogService blogService)
        {
            this.userService = userService;
            this.blogService = blogService;
        }

        public IActionResult Index()
        {

            var users = userService.GetMany(x=>x.IsAdmin==false);
            return View();
        }

        public IActionResult Privacy()
        {

            Blog blog = new Blog()
            {
                Tags="A,B,v"
            };
            

            blogService.Add(blog);

            blogService.PointIncrementation(blog);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
