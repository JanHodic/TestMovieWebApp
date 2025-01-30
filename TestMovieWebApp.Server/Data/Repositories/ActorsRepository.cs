using TestMovieWebApp.Server.Commons.BaseServices;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Data.Repositories
{
    public class ActorsRepository : BaseWriteRepository<Actor, TestWebAppDbContext>, IActorsRepository
    {
        public ActorsRepository(ILogger<Actor> eventLogger, TestWebAppDbContext dbEntity) : base(eventLogger, dbEntity)
        {
        }
    }
}
