using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;

namespace TilesNav.Core.Test
{
    class FakeTilesNavRepositoryWithIntId<TEntity> : FakeTilesNavRepository<TEntity, int> where TEntity : AbstractTilesNavBaseType<int>
    {
        private int _curId = 1;
        protected override int CreateNewId()
        {
            return _curId++;
        }
    }
}
