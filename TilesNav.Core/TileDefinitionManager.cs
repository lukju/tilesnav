using System;
using System.Collections.Generic;
using TilesNav.Core.Interfaces;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;

namespace TilesNav.Core
{
    public class TileDefinitionManager : ITileDefinitionManager
    {
        readonly private ITilesNavRepository<TileDefinition, Guid> _tileDefinitionRepo;
        readonly private User _currentUser;

        public TileDefinitionManager(
            ITilesNavRepository<TileDefinition, Guid> tileDefinitionRepo,
            IUserManager userManager)
        {
            _tileDefinitionRepo = tileDefinitionRepo;
            _currentUser = userManager.CurrentUser;
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
            if (td.Id != Guid.Empty)
            {
                if (GetDefinition(td.Id) == null)
                {
                    throw new InvalidOperationException("definition does not exist");
                }
                return _tileDefinitionRepo.Update(td, _currentUser);
            } else
            {
                return _tileDefinitionRepo.Create(td, _currentUser);
            }
        }
    }
}
