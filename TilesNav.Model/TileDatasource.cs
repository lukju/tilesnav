using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TilesNav.Model
{
    public class TileDatasource: AbstractTilesNavBaseType
    {
        [Required]
        public Guid Secret { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Endpoint { get; set; }
        
    }
}
