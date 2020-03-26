using BlogScript.Bll.Abstract;
using BlogScript.Bll.ComplexTypes;
using BlogScript.Core.Abstract.Dal;
using BlogScript.Dal.Abstract;
using BlogScript.Entities.Concreate;
using BlogScript.Bll.Helpers;
using System.Collections.Generic;

namespace BlogScript.Bll.Concreate
{
    public class UserManager : EntityManager<User>, IUserService { public UserManager(IUserDal repostory) : base(repostory) { } }
    public class CategoryManager : EntityManager<Category>, ICategoryService { public CategoryManager(ICategoryDal repostory) : base(repostory) { } }
    public class CommentManager : EntityManager<Comment>, ICommentService { public CommentManager(ICommentDal repostory) : base(repostory) { } }
    public class BlogManager : EntityManager<Blog>, IBlogService
    {
        public BlogManager(IBlogDal repostory) : base(repostory)
        {
        }

        public override void Add(Blog entity)
        {
            if (!entity.Content.StringEmptyChack())
                base.Add(entity);
        }

        public ICollection<Blog> GetActiveAllBlogs()
        {
            return GetMany(x => x.IsActive == true);
        }

        public void PointIncrementation(Blog blog)
        {
            blog.Points++;
            Update(blog);
            Save();
        }
    }
}
