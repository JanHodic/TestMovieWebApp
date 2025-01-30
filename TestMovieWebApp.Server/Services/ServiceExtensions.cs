using TestMovieWebApp.Server.Commons.Interfaces;
using TestMovieWebApp.Server.Data;
using TestMovieWebApp.Server.Services.Commons;
using TestMovieWebApp.Server.Services.Modules.Actors;
using TestMovieWebApp.Server.Services.Modules.Movies;

namespace TestMovieWebApp.Server.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataServices(configuration);
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IFileReader, FileReader<IActorsService, IMoviesService>>();
            return services;
        }
    }
}
