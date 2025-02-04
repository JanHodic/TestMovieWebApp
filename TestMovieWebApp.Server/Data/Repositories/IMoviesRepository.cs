using TestMovieWebApp.Server.Commons.BaseInterfaces;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Data.Repositories
{
    public interface IMoviesRepository: IBaseReadRepository<Movie>, IBaseWriteRepository<Movie>
    {
        public Task<Movie> FindByTitle(string name);
        public Task<ActorMovie> AddExistingActorToMovie(Guid ActorId, Guid MovieId);
    }
}
