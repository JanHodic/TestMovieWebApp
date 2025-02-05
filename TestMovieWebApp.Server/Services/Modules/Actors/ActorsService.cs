using AutoMapper;
using System.Linq;
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

            //Toto zavru do rekurze a do while cyklu.
            var am = keyPairs.Where(o => o.ActorId == actor1.Id || o.ActorId == actor2.Id).ToList();
            ams.AddRange(am);
            foreach (var a in ams) 
            {
                keyPairs.Remove(a);
            }

            var movieIds = ams.Select(o => o.MovieId).ToList();
            foreach (var movieId in movieIds) 
            {
                var selectedByMovieId = keyPairs.Where(o => o.MovieId == movieId).ToList();
                ams.AddRange(selectedByMovieId);
                foreach(var p in selectedByMovieId)
                {
                    keyPairs.Remove(p);
                }
                var selectedByActorId = keyPairs.Where(o => o.ActorId == movieId).ToList();
            }

            while (keyPairs.Count > 0)
            { 
                
            }
            
            var result = new ActorWithFilmsDto() { Actors = { actor1 } };

            return result;
        }
    }
}
