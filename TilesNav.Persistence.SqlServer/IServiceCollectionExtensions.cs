using Microsoft.EntityFrameworkCore;
using TilesNav.Persistence.SqlServer;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TilesNav.Persistence.SqlServer
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

            services.AddScoped<ITilesNavRepository<TileDefinition>, TilesNavRepository<TileDefinition>>();
            services.AddScoped<ITilesNavRepository<PersonalTilesView>, TilesNavRepository<PersonalTilesView>>();
            services.AddScoped<ITilesNavRepository<DefaultTilesView>, TilesNavRepository<DefaultTilesView>>();
        }
    }
}
