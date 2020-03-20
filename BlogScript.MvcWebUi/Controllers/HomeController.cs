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
using BlogScript.MvcWebUi.Services;

namespace BlogScript.MvcWebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;

        public HomeController(IUserService userService,IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        public IActionResult Index()
        {
            User loginUser = userSessionService.Get("LoginUser");
            return View(loginUser);
        }

        public IActionResult Privacy(User user)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
