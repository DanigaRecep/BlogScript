using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogScript.Bll.Abstract;
using BlogScript.Bll.Concreate;
using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Concreate;
using BlogScript.MvcWebUi.Attributes;
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
        private readonly ILikeService likeService;
        private readonly IBlogViewCounterCookieService blogViewCounterCookieService;

        public BlogController(
            ICategoryService categoryService,
            IUserSessionService userSessionService,
            IBlogService blogService,
            ILikeService likeService,
            IBlogViewCounterCookieService blogViewCounterCookieService)
        {
            this.categoryService = categoryService;
            this.userSessionService = userSessionService;
            this.blogService = blogService;
            this.likeService = likeService;
            this.blogViewCounterCookieService = blogViewCounterCookieService;
        }
        [UserAuthorize]
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

        [UserAuthorize]
        [HttpPost]
        public IActionResult Create(BlogCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                SessionUser user = userSessionService.Get("LoginUser");

                Category category = categoryService.Get(x => x.IsActive == true && x.id == model.Categoryid);
                if (user != null && category != null)
                {
                    Blog blog = new Blog()
                    {
                        Category = category,
                        Content = model.Content,
                        Title = model.Title,
                        Description = model.Discription,
                        Userid = user.id,
                        Tags = model.Tags,
                        CreateUserid = user.id
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
                Categoryid = model.Categoryid,
                Content = model.Content,
                Title = model.Title
            });
        }

        [HttpGet]
        public IActionResult BlogDetail(int id)
        {
            Blog blog = blogService.Get(x => x.id == id && x.IsActive);
            SessionUser session = userSessionService.Get("LoginUser");
            string color = "#6c757d";
            if (EntityBase.IsNotNull(blog) && EntityBase.IsNotNull(session))
            {
                Like like = likeService.Get(x => x.IsActive == true && x.Userid == session.id && x.Blogid == blog.id);
                if (EntityBase.IsNotNull(like))
                    color = like.IsLike ? "#9494FF" : "#FF8b60";
                BlogViewCounterModel blogViewCounterModel = blogViewCounterCookieService.Get($"BlogView-{blog.id}-{session.id}");
                if (blogViewCounterModel==null)
                {
                    blog.ViewCount++;
                    blogService.Update(blog);
                    blogService.Save();
                    blogViewCounterCookieService.Set($"BlogView-{blog.id}-{session.id}", new BlogViewCounterModel()
                    {
                        Blogid = blog.id,
                        Userid = session.id,
                        IsLogin = true
                    }, 60 * 2);
                }
                
            }
            else
            {
                BlogViewCounterModel blogViewCounterModel = blogViewCounterCookieService.Get($"BlogView-{blog.id}-0");
                if (blogViewCounterModel == null)
                {
                    blog.ViewCount++;
                    blogService.Update(blog);
                    blogService.Save();
                    blogViewCounterCookieService.Set($"BlogView-{blog.id}-0", new BlogViewCounterModel()
                    {
                        Blogid = blog.id,
                        IsLogin = false
                    }, 60 * 2);
                }
            }
            ViewBag.PointColor = color;
            return View(blog);
        }

        [HttpGet]
        public JsonResult Increment(int id, int value)
        {
            int val = value;
            int Proc = 0;
            SessionUser session = userSessionService.Get("LoginUser");
            Blog blog = blogService.Get(x => x.id == id && x.IsActive);
            if (EntityBase.IsNotNull(blog) && EntityBase.IsNotNull(session))
            {
                Like like = likeService.Get(x => x.IsActive == true && x.Userid == session.id && x.Blogid == blog.id && x.IsLike == (value == 1));
                if (EntityBase.IsNotNull(like))
                {
                    like.IsActive = false;
                    likeService.Update(like);
                    likeService.Save();
                    val *= -1;
                    Proc = 0;
                }
                else
                {
                    Proc = (value == 1 ? 1 : -1);
                    like = likeService.Get(x => x.IsActive == true && x.Userid == session.id && x.Blogid == blog.id && x.IsLike == !(value == 1));
                    if (EntityBase.IsNotNull(like))
                    {
                        like.IsActive = false;
                        likeService.Update(like);
                        likeService.Save();
                        val *= 2;
                    }
                    like = new Like()
                    {
                        Blogid = blog.id,
                        Userid = session.id,
                        IsLike = (value == 1)
                    };
                    likeService.Add(like);
                    likeService.Save();

                }
                blogService.PointIncrementation(blog, val);
            }
            string color = Proc == 1 ? "#9494FF" : (Proc == -1 ? "#FF8b60" : "#6c757d");
            return Json(new { Point = blog.Points, Color = color });
        }
    }
}