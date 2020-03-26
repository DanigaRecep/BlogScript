using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogScript.Bll.Abstract;
using BlogScript.Entities.Concreate;
using BlogScript.MvcWebUi.Models;
using BlogScript.MvcWebUi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogScript.MvcWebUi.Controllers
{
    public class BlogController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IUserSessionService userSessionService;
        private readonly IBlogService blogService;

        public BlogController(ICategoryService categoryService,IUserSessionService userSessionService,IBlogService blogService)
        {
            this.categoryService = categoryService;
            this.userSessionService = userSessionService;
            this.blogService = blogService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new BlogCreateViewModel()
            {
                Categories = categoryService.GetMany(x => x.IsActive == true).Select(a =>
                                        new SelectListItem
                                        {
                                            Value = a.id.ToString(),
                                            Text = a.Name
                                        }).ToList()
            });
        }


        [HttpPost]
        public IActionResult Create(BlogCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userSessionService.Get("LoginUser");

                Category category = categoryService.Get(x=>x.IsActive==true && x.id==model.Categoryid);
                if (user!=null && category!=null)
                {
                    Blog blog = new Blog()
                    {
                        Category = category,
                        Content = model.Content,
                        Title = model.Title,
                        User=user,
                        Tags=model.Tags,
                        CreateUserid=user.id
                    };
                    blogService.Add(blog);
                    blogService.Save();
                }
                else
                {
                    ViewBag.ErrorMassage = "Kritik Hata";
                }
                
            }
            else
            {
                ViewBag.ErrorMassage = "Tüm bilgileri eksiksiz giriniz.";
            }
            return View(new BlogCreateViewModel()
            {
                Categories = categoryService.GetMany(x => x.IsActive == true).Select(a =>
                                        new SelectListItem
                                        {
                                            Value = a.id.ToString(),
                                            Text = a.Name
                                        }).ToList(),
                Categoryid= model.Categoryid,
                Content= model.Content,
                 Title= model.Title
            });
        }
    }
}