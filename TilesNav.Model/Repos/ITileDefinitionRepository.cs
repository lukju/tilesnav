using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Model.Repos
{
    public interface ITileDefinitionRepository
    {
        IEnumerable<TileDefinition> GetAll();
        TileDefinition Create(TileDefinition tileDefinition);
        TileDefinition Get(int id);
        TileDefinition Update(TileDefinition tileDefinition);
        TileDefinition Delete(int id);
    }
}
