using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Core.Interfaces;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;

namespace TilesNav.Core
{
    class TileDefinitionManager : ITileDefinitionManager
    {
        readonly ITilesNavRepository<TileDefinition> _tileDefinitionRepo;
        readonly IUser _currentUser;

        public TileDefinitionManager(IUser currentUser, ITilesNavRepository<TileDefinition> tileDefinitionRepo)
        {
            _tileDefinitionRepo = tileDefinitionRepo;
            _currentUser = currentUser;
        }

        public TileDefinition DeleteDefinition(int id)
        {
            return _tileDefinitionRepo.Delete(id);
        }

        public IEnumerable<TileDefinition> GetAll()
        {
            return _tileDefinitionRepo.GetAll();
        }

        public TileDefinition GetDefinition(int id)
        {
            return _tileDefinitionRepo.Get(id);
        }

        public TileDefinition SaveDefinition(TileDefinition td)
        {
            if (td.ID > 0)
            {
                return _tileDefinitionRepo.Update(td);
            } else
            {
                return _tileDefinitionRepo.Create(td);
            }
        }
    }
}
