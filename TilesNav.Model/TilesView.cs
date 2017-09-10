using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace TilesNav.Model
{
    public abstract class TilesView: AbstractTilesNavBaseType<int>
    {
        public TilesNavViewer Viewer { get; set; }
        public List<TilesViewContainer> Containers { get; set; }
        protected override bool HasAssignedId => Id > 0;
    }
}
