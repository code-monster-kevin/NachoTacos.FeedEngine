using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NachoTacos.FeedEngine.Data
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services,
            string connectionString)
        {
            services
                .AddDbContext<FeedEngineContext>(
                    options =>
                        options.UseSqlServer(connectionString)
                );
        }
    }
}
