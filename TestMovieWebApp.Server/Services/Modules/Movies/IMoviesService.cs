using TestMovieWebApp.Server.Commons.BaseInterfaces;
using TestMovieWebApp.Server.Dtos;

namespace TestMovieWebApp.Server.Services.Modules.Movies
{
    public interface IMoviesService: IBaseReadService<MovieDto>, IBaseWriteService<MovieDto, MovieDto>
    {
    }
}
