using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;

namespace TilesNav.Core.Test
{
    abstract class FakeTilesNavRepository<TEntity, TID> : ITilesNavRepository<TEntity, TID> where TEntity : AbstractTilesNavBaseType<TID> 
    {
        private readonly List<TEntity> _repo = new List<TEntity>();

        public TEntity Create(TEntity entity)
        {
            entity.Modified = DateTime.Now;
            entity.ID = CreateNewId();
            _repo.Add(entity);
            return entity;
        }

        protected abstract TID CreateNewId();

        public TEntity Delete(TID id)
        {
            TEntity toDelete = Get(id);
            _repo.Remove(toDelete);
            return toDelete;
        }

        public TEntity Get(TID id)
        {
            var result = (from t in _repo where t.ID.Equals(id) select t)
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            List<TEntity> entities = _repo;
            if (filter != null)
            {
                entities = entities.Where(filter.Compile()).ToList();
            }
            return entities;
        }

        public TEntity Update(TEntity entity)
        {
            entity.Modified = DateTime.Now;
            Delete(entity.ID);
            _repo.Add(entity);
            return entity;
        }
    }
}
