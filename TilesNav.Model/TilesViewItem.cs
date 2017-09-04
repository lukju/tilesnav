using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TilesNav.Model
{
    public class TilesViewItem
    {
        [Required]
        public TileDefinition Definition { get; set; }
        public string ItemSpecificConfig { get; set; }
        [Key]
        public int X { get; set; }
        [Key]
        public int Y { get; set; }
        [Key]
        public TilesViewContainer Container { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
    }
}
