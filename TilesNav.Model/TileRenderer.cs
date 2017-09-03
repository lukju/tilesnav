using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TilesNav.Model
{
    public class TileRenderer: AbstractTilesNavBaseType<Guid>
    {
        [Required]
        public Guid Secret { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        
    }
}
