using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Model
{
    public abstract class AbstractTilesNavBaseType<TKey>
    {
        public TKey ID { get; set; }

        public DateTime Modified { get; set; }
        
        public DateTime Created { get; set; }

        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
    }
}
