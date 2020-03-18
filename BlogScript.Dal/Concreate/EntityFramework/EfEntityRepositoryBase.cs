using BlogScript.Core.Abstract.Dal;
using BlogScript.Core.Concreate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace BlogScript.Dal.Concreate.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : EntityBase, new()
        where TContext : DbContext, new()
    {
        private DbContext dbContext = null;
        private DbSet<TEntity> table = null;
        private object LockObj = new object();
        public EfEntityRepositoryBase()
        {
            Build();
            table = dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            var _entity = dbContext.Entry<TEntity>(entity);
            _entity.State = EntityState.Added;
        }

        public virtual void Build()
        {
            lock (LockObj)
                if (dbContext == null || !(dbContext is TContext))
                    dbContext = new TContext();
        }

        public virtual void Delete(TEntity entity)
        {
            entity.IsActive = false;
            var _entity = dbContext.Entry<TEntity>(entity);
            _entity.State = EntityState.Modified;
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> filter)
        {
            if (filter != null)
            {
                var entities = table.Where(filter);
                foreach (TEntity entity in entities)
                    Delete(entity);
            }
        }

        public virtual async void Dispose()
        {
            if (dbContext != null)
                await dbContext.DisposeAsync();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] navigations)
        {
            var set = table.AsQueryable();
            navigations.ToList().ForEach(item =>
            {
                set.Include(item);
            });
            return set.FirstOrDefault(filter);
        }

        public virtual ICollection<TEntity> GetAll(params string[] navigations)
        {
            var set = table.AsQueryable();
            navigations.ToList().ForEach(item =>
            {
                set.Include(item);
            });
            return set.ToList();
        }

        public virtual ICollection<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null, params string[] navigations)
        {
            var set = table.AsQueryable();
            navigations.ToList().ForEach(item =>
            {
                set.Include(item);
            });
            return filter == null ? set.ToList() : set.Where(filter).ToList();
        }

        public virtual void Save()
        {
            dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            var _entity = dbContext.Entry<TEntity>(entity);
            _entity.State = EntityState.Modified;
        }

        public int _Save() => dbContext.SaveChanges();
    }
}
