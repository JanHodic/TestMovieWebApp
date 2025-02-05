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

        public async Task<ActorWithFilmsDto> GetActorWithFilms(string name1, string name2)
        {
            var actor1 = await _repository.FindByName(name1);
            var actor2 = await _repository.FindByName(name2);

            var keyPairs = await _repository.ReturnAllKeyPairs();
            List<ActorMovie> ams = new List<ActorMovie>();
            IDictionary<Guid, Guid> pairs = new Dictionary<Guid, Guid>();
            foreach (var keyPair in keyPairs) 
            {
                pairs.Add(keyPair.ActorId, keyPair.MovieId);
            }

            var result = new ActorWithFilmsDto() { Actors = { actor1 } };

            return result;
        }
    }
}
