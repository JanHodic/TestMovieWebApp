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
            var movies1 = actor1.Movies;
            var movies2 = actor2.Movies;

            var result = new ActorWithFilmsDto() { Actors = { actor1 } };

            foreach (var m1 in movies1)
            {
                if (movies2.Contains(m1))
                {
                    result.Movies.Add(m1);
                    result.Actors.Add(actor2);
                }
                else 
                {
                    
                }
            }

            return result;
        }
    }
}
