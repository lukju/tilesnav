using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Models
{
    public class TileDefinition
    {
        public int Id { get; set; }
        public int DefinitionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public TileDatasource Datasource { get; set; }
        public TileRenderer Renderer { get; set; }

    }
}
