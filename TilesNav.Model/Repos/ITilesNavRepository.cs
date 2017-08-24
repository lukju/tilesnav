using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Model.Repos
{
    public interface ITilesNavRepository<T> where T: AbstractTilesNavBaseType
    {
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Get(int id);
        T Update(T entity);
        T Delete(int id);
    }
}
