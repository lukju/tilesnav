using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TilesNav.Persistence.SqlServer;
using TilesNav.Model.Repos;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureTilesNavWithSqlServer(this IServiceCollection services)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=TilesNavDev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContextPool<TilesContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ITileDefinitionRepository, TileDefinitionRepository>();
        }
    }
}
