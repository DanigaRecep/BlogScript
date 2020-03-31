using BlogScript.Core.Abstract.Dal;
using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Bll.Abstract
{
    public interface IUserService : IEntityRepository<User> { }
    public interface ICommentService : IEntityRepository<Comment> { }
    public interface ILikeService : IEntityRepository<Like> { }
    public interface ICategoryService : IEntityRepository<Category> { }
    public interface IBlogService : IEntityRepository<Blog>
    {
        void PointIncrementation(Blog blog,int value);
    }
}
