using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;

namespace TilesNav.Core.Interfaces
{
    public interface ITileDefinitionManager
    {
        TileDefinition SaveDefinition(TileDefinition td);
        TileDefinition DeleteDefinition(Guid id);
        TileDefinition GetDefinition(Guid id);
        IEnumerable<TileDefinition> GetAll();

    }
}
