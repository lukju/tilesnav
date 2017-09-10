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

        public DbSet<PersonalTilesView> PersonalTilesViews { get; set; }

        public DbSet<DefaultTilesView> DefaultTilesViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TilesNavViewer>()
                .Property(v => v.Id).ValueGeneratedNever();

            modelBuilder.Entity<TilesViewContainer>()
                .HasKey(c => new { c.Position, c.ViewId });
        }
    }
    
}
