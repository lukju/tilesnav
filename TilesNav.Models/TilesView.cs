using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Models
{
    public class TilesView
    {
        public int Id { get; set; }
        public List<TilesViewContainer> Containers { get; set; }
    }
}
