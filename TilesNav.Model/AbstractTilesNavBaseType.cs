using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Model
{
    public abstract class AbstractTilesNavBaseType<T_ID>
    {
        public T_ID ID { get; set; }

        public DateTime Modified { get; set; }
    }
}
