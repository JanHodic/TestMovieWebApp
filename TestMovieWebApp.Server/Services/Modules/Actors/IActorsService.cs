using TestMovieWebApp.Server.Commons.BaseInterfaces;
using TestMovieWebApp.Server.Dtos;

namespace TestMovieWebApp.Server.Services.Modules.Actors
{
    public interface IActorsService: IBaseReadService<ActorDto>, IBaseWriteService<ActorDto, ActorDto>
    {
        public Task<ActorWithFilmsDto> GetActorWithFilms(string name1, string name2);
    }
}
