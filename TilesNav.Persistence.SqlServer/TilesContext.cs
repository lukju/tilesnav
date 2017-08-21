using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TilesNav.Model;

namespace TilesNav.Persistence.SqlServer
{
    class TilesContext : DbContext
    {
        public TilesContext(DbContextOptions<TilesContext> options) : base(options) { }

        public DbSet<TileDefinition> TileDefinitions { get; set; }

        public DbSet<TilesView> TilesViews { get; set; }
    }
    
}
