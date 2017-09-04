using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TilesNav.Model
{
    public class TilesViewContainer
    {
        [Key]
        public int Position { get; set; }
        [Key]
        public TilesView View { get; set; }
        public string Title { get; set; }
        public List<TilesViewItem> Tiles { get; set; }
    }
}
