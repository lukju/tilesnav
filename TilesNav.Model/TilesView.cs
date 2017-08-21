using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace TilesNav.Model
{
    public class TilesView
    {
        public int ID { get; set; }
        public List<TilesViewContainer> Containers { get; set; }
    }
}
