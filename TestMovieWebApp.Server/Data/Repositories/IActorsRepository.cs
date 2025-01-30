using TestMovieWebApp.Server.Commons.BaseInterfaces;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Data.Repositories
{
    public interface IActorsRepository: IBaseReadRepository<Actor>, IBaseWriteRepository<Actor>
    {
    }
}
