using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TilesNav.Model
{
    public class User: AbstractTilesNavBaseType<int>
    {
        [Required]
        public string AccountName { get; set; }

        protected override bool HasAssignedId => Id > 0;
    }
}
