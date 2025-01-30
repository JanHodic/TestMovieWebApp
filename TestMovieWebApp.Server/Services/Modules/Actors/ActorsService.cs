using AutoMapper;
using TestMovieWebApp.Server.Commons.BaseServices;
using TestMovieWebApp.Server.Data.Repositories;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Services.Modules.Actors
{
    public class ActorsService : BaseWriteService<IActorsRepository, Actor, ActorDto, ActorDto>, IActorsService
    {
        public ActorsService(ILogger<Actor> eventLogger, IActorsRepository repository, IMapper mapper) : base(eventLogger, repository, mapper)
        {
        }
    }
}
