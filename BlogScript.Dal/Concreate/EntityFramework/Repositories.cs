using BlogScript.Dal.Abstract;
using BlogScript.Dal.Concreate.EntityFramework.Contexts;
using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Dal.Concreate.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BlogScriptDbContext>, IUserDal { }
    public class EfCommentDal : EfEntityRepositoryBase<Comment, BlogScriptDbContext>, ICommentDal { }
    public class EfCategoryDal : EfEntityRepositoryBase<Category, BlogScriptDbContext>, ICategoryDal { }
    public class EfBlogDal : EfEntityRepositoryBase<Blog, BlogScriptDbContext>, IBlogDal { }
    public class EfLikeDal : EfEntityRepositoryBase<Like, BlogScriptDbContext>, ILikeDal { }

}
