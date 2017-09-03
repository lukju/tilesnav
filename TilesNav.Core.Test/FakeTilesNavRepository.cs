using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;

namespace TilesNav.Core.Test
{
    class FakeTilesNavRepository<T> : ITilesNavRepository<T> where T : AbstractTilesNavBaseType
    {
        private readonly List<T> _repo = new List<T>();
        private int _curId = 1; 
        public T Create(T entity)
        {
            entity.Modified = DateTime.Now;
            entity.ID = _curId++;
            _repo.Add(entity);
            return entity;
        }

        public T Delete(int id)
        {
            T toDelete = Get(id);
            _repo.Remove(toDelete);
            return toDelete;
        }

        public T Get(int id)
        {
            var result = (from t in _repo where t.ID == id select t)
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            List<T> entities = _repo;
            if (filter != null)
            {
                entities = entities.Where(filter.Compile()).ToList();
            }
            return entities;
        }

        public T Update(T entity)
        {
            entity.Modified = DateTime.Now;
            Delete(entity.ID);
            _repo.Add(entity);
            return entity;
        }
    }
}
