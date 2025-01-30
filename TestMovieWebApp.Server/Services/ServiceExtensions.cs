using TestMovieWebApp.Server.Data;

namespace TestMovieWebApp.Server.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataServices(configuration);
            return services;
        }
    }
}
