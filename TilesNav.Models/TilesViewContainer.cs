using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Models
{
    public class TilesViewContainer
    {
        public int Id { get; set; }
        public List<TilesViewItem> Tiles { get; set; }
    }
}
