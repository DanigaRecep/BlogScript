using System;
using BlogScript.Bll.Abstract;
using BlogScript.Bll.Helpers;
using BlogScript.Entities.Concreate;
using BlogScript.MvcWebUi.Models;
using BlogScript.MvcWebUi.Services;
using Microsoft.AspNetCore.Mvc;


using static BlogScript.Bll.Helpers.RegexUtilities;
using static BlogScript.Bll.Helpers.ToPasswordRepository;
using static BlogScript.Bll.Helpers.PasswordCheck;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using BlogScript.Bll.Concreate;

namespace BlogScript.MvcWebUi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;
        private readonly IHostingEnvironment hostingEnvironment;

        public LoginController(IUserService userService, IUserSessionService userSessionService, IHostingEnvironment hostingEnvironment)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(string username = "")
        {
            return View(new UserViewModel());
        }
        [HttpPost]
        public IActionResult Index(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = ToPasswordRepository.PasswordCryptographyCombine(model.Password);

                User foundUser = userService.Get(x => x.UserName.Equals(model.UserName) && x.Password.Equals(model.Password));
                if (foundUser != null)
                {
                    foundUser.UpdateDate = DateTime.UtcNow;
                    foundUser.UpdateUserid = foundUser.id;
                    userService.Update(foundUser);
                    userService.Save();
                    SessionUser session = new SessionUser();
                    foundUser.UserToSession(ref session);
                    userSessionService.Set(session, "LoginUser");
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    ViewBag.AlertMassage = "Girdiginiz bilgiler ile eslesen bir kayit bulunamadi.";
                }
            }
            else
            {
                ViewBag.AlertMassage = "Lutfen bilgileri dogru giriniz.";
            }
            return View(model);
        }


        public IActionResult Register()
        {
            return View(new UserRegisterViewModel());
        }
        [HttpPost]
        public IActionResult Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userService.Get(x => x.Email.Equals(model.Email) || x.UserName.Equals(model.UserName));
                if (user != null)
                {
                    ViewBag.RegisterAlertMassage = "Email adresi veya Kullanici adi daha önce kullanılmış.";
                    return View(model);
                }

                bool valid = IsValidEmail(model.Email) && (int)GetPasswordStrength(model.Password) > 2;
                if (valid && model.ProfilePhoto != null)
                {
                    model.Password = PasswordCryptographyCombine(model.Password);

                    string uniqueFileName = null;
                    string ex = Path.GetExtension(model.ProfilePhoto.FileName);
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "UserImages");
                    uniqueFileName = Guid.NewGuid().ToString().Replace("-", "") + "_" + model.UserName + ex;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.ProfilePhoto.CopyTo(new FileStream(filePath, FileMode.Create));

                    user = new User()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        ProfilePhoto = uniqueFileName,
                        Email = model.Email,
                        Password = model.Password,
                        UserName = model.UserName
                    };

                    userService.Add(user);
                    userService.Save();
                    return RedirectToAction("Index", "Login", new { area = "", username = user.UserName });
                }
            }

            ViewBag.RegisterAlertMassage = "Tüm bilgileri eksiksiz ve doğru biçimde girdiğinizden emin olunuz.";

            return View(model);
        }

        public IActionResult Logout()
        {
            SessionUser user = userSessionService.Get("LoginUser");
            if (user != null)
                userSessionService.Set(null, "LoginUser");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}