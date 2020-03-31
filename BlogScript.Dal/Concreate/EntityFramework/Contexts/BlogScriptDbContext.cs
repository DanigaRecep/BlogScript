using BlogScript.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Dal.Concreate.EntityFramework.Contexts
{
    public class BlogScriptDbContext : DbContext
    {

        /*
            install-package Microsoft.EntityFrameworkCore.Proxies 
            install-package Microsoft.EntityFrameworkCore.Abstractions
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DANIGA-PC\SQLEXPRESS;Initial Catalog=BlogScript;Integrated Security=True");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
