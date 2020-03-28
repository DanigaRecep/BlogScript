using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concreate
{
    using Microsoft.EntityFrameworkCore.Infrastructure;
    public class User : EntityBase, IUser
    {
        private readonly ILazyLoader lazyLoader;

        public User()
        {

        }

        public User(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ProfilePhoto { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        /// <summary>
        ///  Admin:true
        ///  Standart:false
        /// </summary>
        public bool IsAdmin { get; set; } = false;

        private ICollection<Blog> _blogs;
        public virtual ICollection<Blog> Blogs 
        {
            get => lazyLoader.Load(this, ref _blogs);
            set => _blogs = value;
        }


        private ICollection<Comment> _comments;
        public virtual ICollection<Comment> Comments
        {
            get => lazyLoader.Load(this, ref _comments);
            set => _comments = value;
        }

    }
}
