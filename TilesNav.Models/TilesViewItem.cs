using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Models
{
    public class TilesViewItem
    {
        public int Id { get; set; }
        public TileDefinition Definition { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
