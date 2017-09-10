using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TilesNav.Model
{
    public class TilesViewItem: AbstractTilesNavBaseType<Guid>
    {
        [Required]
        public TileDefinition Definition { get; set; }
        public string JsonSerializedConfig { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        
        protected override bool HasAssignedId => Id != null && Id != Guid.Empty;
    }
}
