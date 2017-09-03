using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;

namespace TilesNav.Persistence.SqlServer
{
    class TilesNavRepository<TEntity, TID> : ITilesNavRepository<TEntity, TID> where TEntity: AbstractTilesNavBaseType<TID>
    {
        private readonly TilesContext _ctx;

        public TilesNavRepository(TilesContext ctx)
        {
            _ctx = ctx;
        }
        public TEntity Create(TEntity entity)
        {
            entity.Modified = DateTime.Now;
            EntityEntry<TEntity> added = _ctx.Set<TEntity>().Add(entity);
            _ctx.SaveChanges();
            return added.Entity;
        }

        public TEntity Delete(TID id)
        {
            TEntity toDelete = Get(id);
            EntityEntry<TEntity> deleted = _ctx.Remove(toDelete);
            _ctx.SaveChanges();
            return deleted.Entity;
        }

        public TEntity Get(TID id)
        {
            var result = (from t in _ctx.Set<TEntity>() where t.ID.Equals(id) select t)
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

        public TEntity Update(TEntity entity)
        {
            entity.Modified = DateTime.Now;
            EntityEntry<TEntity> updated = _ctx.Update(entity);
            _ctx.SaveChanges();
            return updated.Entity;
        }
    }
}
