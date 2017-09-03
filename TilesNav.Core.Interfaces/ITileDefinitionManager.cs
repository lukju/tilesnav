using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;

namespace TilesNav.Core.Interfaces
{
    public interface ITileDefinitionManager
    {
        TileDefinition SaveDefinition(TileDefinition td);
        TileDefinition DeleteDefinition(int id);
        TileDefinition GetDefinition(int id);
        IEnumerable<TileDefinition> GetAll();

    }
}
