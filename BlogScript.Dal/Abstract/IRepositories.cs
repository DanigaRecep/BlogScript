﻿using BlogScript.Core.Abstract.Dal;
using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Dal.Abstract
{
    public interface IUserDal : IEntityRepository<User> { };   
    public interface ICategoryDal : IEntityRepository<Category> { };   
    public interface ICommentDal : IEntityRepository<Comment> { };
    public interface IBlogDal : IEntityRepository<Blog> { };
    public interface ILikeDal : IEntityRepository<Like> { };
}
