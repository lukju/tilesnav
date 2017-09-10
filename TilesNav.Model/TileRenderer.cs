using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TilesNav.Model
{
    public class TileRenderer: AbstractTilesNavBaseType<Guid>
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        protected override bool HasAssignedId => Id != null && Id != Guid.Empty;
    }
}
