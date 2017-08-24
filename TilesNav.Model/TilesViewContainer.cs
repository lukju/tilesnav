using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TilesNav.Model
{
    public class TilesViewContainer: AbstractTilesNavBaseType
    {
        public List<TilesViewItem> Tiles { get; set; }
    }
}
