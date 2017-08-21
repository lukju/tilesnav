﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TilesNav.Model
{
    public class TileDefinition
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int DatasourceId { get; set; }
        [Required]
        public TileDatasource Datasource { get; set; }
        [Required]
        public int RendererId { get; set; }
        public TileRenderer Renderer { get; set; }
    }
}