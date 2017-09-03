using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;

namespace TilesNav.Persistence.SqlServer
{
    class TilesNavRepository<T> : ITilesNavRepository<T> where T: AbstractTilesNavBaseType
    {
        private readonly TilesContext _ctx;

        public TilesNavRepository(TilesContext ctx)
        {
            _ctx = ctx;
        }
        public T Create(T entity)
        {
            entity.Modified = DateTime.Now;
            EntityEntry<T> added = _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
            return added.Entity;
        }

        public T Delete(int id)
        {
            T toDelete = Get(id);
            EntityEntry<T> deleted = _ctx.Remove(toDelete);
            _ctx.SaveChanges();
            return deleted.Entity;
        }

        public T Get(int id)
        {
            var result = (from t in _ctx.Set<T>() where t.ID == id select t)
                .FirstOrDefault();
            
            return result;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _ctx.Set<T>();
            if (filter != null)
            {
                query.Where(filter);
            }
            return query;
        }

        public T Update(T entity)
        {
            entity.Modified = DateTime.Now;
            EntityEntry<T> updated = _ctx.Update(entity);
            _ctx.SaveChanges();
            return updated.Entity;
        }
    }
}
