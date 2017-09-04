using System;
using TilesNav.Persistence.SqlServer;
using TilesNav.Model;
using TilesNav.Persistence.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TilesNav.Core.Interfaces;
using TilesNav.Core;

namespace TilesNav.Persistence.SqlServer
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureTilesNavCore(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ITileDefinitionManager, TileDefinitionManager>();
            services.AddScoped<ITilesViewManager, TilesViewManager>();
        }
    }
}
