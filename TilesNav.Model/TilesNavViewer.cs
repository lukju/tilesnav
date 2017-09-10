using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Model
{
    public class TilesNavViewer : AbstractTilesNavBaseType<string>
    {
        public string Description { get; set; }
        protected override bool HasAssignedId => !string.IsNullOrEmpty(Id);
    }
}
