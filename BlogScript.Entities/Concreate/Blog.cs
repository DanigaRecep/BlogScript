using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concreate
{
    public class Blog:EntityBase,IBlog
    {
        private readonly ILazyLoader lazyLoader;

        public Blog()
        {

        }
        public Blog(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public int Categoryid { get; set; }
        public virtual Category Category { get; set; }

        public int Userid { get; set; }
        public virtual User User { get; set; }

        public string Title { get; set; }

        public int ViewCount { get; set; }
        public int Points { get; set; }
        public string Tags { get; set; }

        public string Content { get; set; }
        public string Description { get; set; }

        public bool Privacy { get; set; }


        private ICollection<Comment> _comments;
        public virtual ICollection<Comment>  Comments 
        {
            get => lazyLoader.Load(this,ref _comments);
            set=>_comments=value; 
        }
    }
}
