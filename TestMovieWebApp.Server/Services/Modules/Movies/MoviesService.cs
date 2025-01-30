using AutoMapper;
using TestMovieWebApp.Server.Commons.BaseServices;
using TestMovieWebApp.Server.Data.Repositories;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Services.Modules.Movies
{
    public class MoviesService : BaseWriteService<IMoviesRepository, Movie, MovieDto, MovieDto>, IMoviesService
    {
        public MoviesService(ILogger<Movie> eventLogger, IMoviesRepository repository, IMapper mapper) : base(eventLogger, repository, mapper)
        {
        }
    }
}
