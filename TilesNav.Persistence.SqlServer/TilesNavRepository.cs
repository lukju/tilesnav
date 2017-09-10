using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;

namespace TilesNav.Persistence.SqlServer
{
    class TilesNavRepository<TEntity, TKey> : ITilesNavRepository<TEntity, TKey> where TEntity : AbstractTilesNavBaseType<TKey>
    {
        private readonly TilesContext _ctx;

        public TilesNavRepository(TilesContext ctx)
        {
            _ctx = ctx;
        }
        public TEntity Create(TEntity entity, User createdBy)
        {
            entity.Created = DateTime.Now;
            entity.CreatedBy = createdBy;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = createdBy;
            EntityEntry<TEntity> added = _ctx.Set<TEntity>().Add(entity);
            _ctx.SaveChanges();
            return added.Entity;
        }

        public TEntity Delete(TKey id)
        {
            TEntity toDelete = Get(id);
            EntityEntry<TEntity> deleted = _ctx.Remove(toDelete);
            _ctx.SaveChanges();
            return deleted.Entity;
        }

        public TEntity Get(TKey id)
        {
            var result = (from t in _ctx.Set<TEntity>() where t.Id.Equals(id) select t)
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _ctx.Set<TEntity>();
            if (filter != null)
            {
                query.Where(filter);
            }
            return query;
        }

        public TEntity Update(TEntity entity, User modifiedBy)
        {
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = modifiedBy;
            EntityEntry<TEntity> updated = _ctx.Update(entity);
            _ctx.SaveChanges();
            return updated.Entity;
        }
    }
}
