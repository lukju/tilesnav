using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using TilesNav.Model;
using TilesNav.Model.Repos;

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

        public IEnumerable<T> GetAll()
        {
            return _ctx.Set<T>();
        }

        public T Update(T entity)
        {
            EntityEntry<T> updated = _ctx.Update(entity);
            _ctx.SaveChanges();
            return updated.Entity;
        }
    }
}
