using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;

namespace TilesNav.Core.Test
{
    class FakeTilesNavRepositoryWithStringId<TEntity> : FakeTilesNavRepository<TEntity, string> where TEntity : AbstractTilesNavBaseType<string>
    {
        private int _curId = 1;
        protected override string CreateNewId()
        {
            return (_curId++).ToString();
        }
    }
}
