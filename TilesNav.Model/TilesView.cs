using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace TilesNav.Model
{
    public class TilesView: AbstractTilesNavBaseType
    {
        public List<TilesViewContainer> Containers { get; set; }
    }
}
