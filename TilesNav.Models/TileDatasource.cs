using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Models
{
    public class TileDatasource
    {
        public int Id { get; set; }
        public Guid Secret { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
