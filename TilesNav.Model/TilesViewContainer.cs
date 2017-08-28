using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TilesNav.Model
{
    public class TilesViewContainer: AbstractTilesNavBaseType
    {
        public string Title { get; set; }

        public string SerializedTiles { get; set; }

        [NotMapped]
        public List<TilesViewItem> Tiles {
            get
            {
                return JsonConvert.DeserializeObject<List<TilesViewItem>>(SerializedTiles);
            }
        }
    }
}
