using BlogScript.Bll.Abstract;
using BlogScript.Bll.ComplexTypes;
using BlogScript.Core.Abstract.Dal;
using BlogScript.Entities.Concreate;

namespace BlogScript.Bll.Concreate
{
    public class UserManager : EntityManager<User>, IUserService { public UserManager(IEntityRepository<User> repostory) : base(repostory) { } }
    public class CommentManager : EntityManager<Comment>, ICommentService { public CommentManager(IEntityRepository<Comment> repostory) : base(repostory) { } }
    public class BlogManager : EntityManager<Blog>, IBlogService 
    {
        public BlogManager(IEntityRepository<Blog> repostory) : base(repostory) 
        {
        }
        

        public override void Add(Blog entity)
        {
            if (entity.Content.Length>0)
            {
                base.Add(entity);
            }
        }

        public void PointIncrementation(Blog blog)
        {
            blog.Points++;
            Update(blog);
        }
    }
}
