using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TilesNav.Persistence.SqlServer
{
    class TilesDbContextFactory : IDesignTimeDbContextFactory<TilesContext>
    {
        public TilesContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TilesContext>();
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=TilesNavDev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            builder.UseSqlServer(connectionString);
            return new TilesContext(builder.Options);
        }
    }
}
