using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TilesNav.Model
{
    public class TileDatasource
    {
        public int ID { get; set; }
        [Required]
        public Guid Secret { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
