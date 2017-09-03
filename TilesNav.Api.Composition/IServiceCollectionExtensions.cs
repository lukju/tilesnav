using TilesNav.Persistence.SqlServer;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureTilesNavServices(this IServiceCollection services)
        {
            services.ConfigureTilesNavWithSqlServer();
        }
    }
}
