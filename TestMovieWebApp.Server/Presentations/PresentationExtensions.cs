using TestMovieWebApp.Server.Services;

namespace TestMovieWebApp.Server.Presentations
{
    public static class PresentationExtensions
    {
        public static IServiceCollection AddPresentations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices(configuration);
            return services;
        }
    }
}
