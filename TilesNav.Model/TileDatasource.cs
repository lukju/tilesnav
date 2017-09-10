using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TilesNav.Model
{
    public class TileDatasource: AbstractTilesNavBaseType<Guid>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Endpoint { get; set; }

        protected override bool HasAssignedId => Id != null && Id != Guid.Empty;
    }
}
