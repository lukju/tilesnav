using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TilesNav.Model;

namespace TilesNav.Persistence.Interfaces
{
    public interface ITilesNavRepository<T> where T: AbstractTilesNavBaseType
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Create(T entity);
        T Get(int id);
        T Update(T entity);
        T Delete(int id);
    }
}
