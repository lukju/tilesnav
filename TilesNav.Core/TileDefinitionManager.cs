using System;
using System.Collections.Generic;
using TilesNav.Core.Interfaces;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;

namespace TilesNav.Core
{
    public class TileDefinitionManager : ITileDefinitionManager
    {
        readonly ITilesNavRepository<TileDefinition, Guid> _tileDefinitionRepo;

        public TileDefinitionManager(ITilesNavRepository<TileDefinition, Guid> tileDefinitionRepo)
        {
            _tileDefinitionRepo = tileDefinitionRepo;
        }

        public TileDefinition DeleteDefinition(Guid id)
        {
            return _tileDefinitionRepo.Delete(id);
        }

        public IEnumerable<TileDefinition> GetAll()
        {
            return _tileDefinitionRepo.GetAll();
        }

        public TileDefinition GetDefinition(Guid id)
        {
            return _tileDefinitionRepo.Get(id);
        }

        public TileDefinition SaveDefinition(TileDefinition td)
        {
            if (td.ID != Guid.Empty)
            {
                if (GetDefinition(td.ID) == null)
                {
                    throw new InvalidOperationException("definition does not exist");
                }
                return _tileDefinitionRepo.Update(td);
            } else
            {
                return _tileDefinitionRepo.Create(td);
            }
        }
    }
}
