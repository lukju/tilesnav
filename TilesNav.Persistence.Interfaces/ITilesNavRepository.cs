﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TilesNav.Model;

namespace TilesNav.Persistence.Interfaces
{
    public interface ITilesNavRepository<TEntity, TID> where TEntity: AbstractTilesNavBaseType<TID>
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Create(TEntity entity);
        TEntity Get(TID id);
        TEntity Update(TEntity entity);
        TEntity Delete(TID id);
    }
}
