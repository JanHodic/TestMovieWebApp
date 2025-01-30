using TestMovieWebApp.Server.Commons.BaseServices;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Data.Repositories
{
    public class MoviesRepository : BaseWriteRepository<Movie, TestWebAppDbContext>, IMoviesRepository
    {
        public MoviesRepository(ILogger<Movie> eventLogger, TestWebAppDbContext dbEntity) : base(eventLogger, dbEntity)
        {
        }
    }
}
