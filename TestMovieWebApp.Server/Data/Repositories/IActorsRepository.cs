using TestMovieWebApp.Server.Commons.BaseInterfaces;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Data.Repositories
{
    public interface IActorsRepository: IBaseReadRepository<Actor>, IBaseWriteRepository<Actor>
    {
        public Task<Actor> FindByName(string name);

        public Task<ICollection<ActorMovie>> ReturnAllKeyPairs();
    }
}
