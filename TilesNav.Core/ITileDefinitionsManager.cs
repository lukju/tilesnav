using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TilesNav.Model;

namespace TilesNav.Core
{
    public interface ITileDefinitionsManager
    {
        Task<ICollection<TileDefinition>> QueryProviders();


    }
}
