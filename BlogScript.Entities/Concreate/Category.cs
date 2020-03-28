using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concreate
{
    public class Category:EntityBase,ICategory
    {
        private readonly ILazyLoader lazyLoader;

        public Category()
        {

        }
        public Category(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public string Name { get; set; }
        public int ParentID { get; set; }

        private ICollection<Blog> _blogs;

        public virtual ICollection<Blog> Blogs 
        {
            get => lazyLoader.Load(this,ref _blogs);
            set => _blogs = value;
        }
    }
}
