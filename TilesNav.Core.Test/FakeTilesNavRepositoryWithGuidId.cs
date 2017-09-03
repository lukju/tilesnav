using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;

namespace TilesNav.Core.Test
{
    class FakeTilesNavRepositoryWithGuidId<TEntity> : FakeTilesNavRepository<TEntity, Guid> where TEntity : AbstractTilesNavBaseType<Guid>
    {
        protected override Guid CreateNewId()
        {
            return Guid.NewGuid();
        }
    }
}
