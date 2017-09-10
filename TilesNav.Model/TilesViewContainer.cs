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
        public int Position { get; set; }
        public int ViewId { get; set; }
        public TilesView View { get; set; }
        public string Title { get; set; }
        public List<TilesViewItem> Tiles { get; set; }
    }
}
