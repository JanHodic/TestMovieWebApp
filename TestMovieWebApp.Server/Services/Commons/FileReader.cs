using TestMovieWebApp.Server.Commons.Interfaces;
using TestMovieWebApp.Server.Dtos;
using System.Text.Json.Nodes;
using TestMovieWebApp.Server.Entities;
using TestMovieWebApp.Server.Data.Repositories;
using AutoMapper;

namespace TestMovieWebApp.Server.Services.Commons
{
    public class FileReader: IFileReader
    {
        private readonly IMoviesRepository _service;
        private readonly IActorsRepository _actorsRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public FileReader(IMoviesRepository service,
            IActorsRepository actorsRepository,
            IMapper mapper, 
            IConfiguration configuration) 
        {
            _service = service;
            _actorsRepository = actorsRepository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<ICollection<MovieDto>> ReadFile()
        {
            var insertedMoviesIds = new List<Guid>();
            try
            {
                //provide to reader your complete text file
                using (StreamReader sr = new StreamReader("Data.json"))
                {
                    String line = sr.ReadToEnd();
                    JsonNode content = JsonNode.Parse(line);
                    var moviesJson = content["movies"].AsArray();
                    foreach (var movie in moviesJson) 
                    {
                        var m = new Movie();
                        m.Title = movie["title"].ToString();
                        var cast = movie["cast"].AsArray();
                        var oldMovie = await _service.FindByTitle(m.Title) ?? null;
                        if (oldMovie != null)
                        {
                            continue;
                        }

                        var mov = await _service.CreateAsync(m);
                        var movieId = mov.Id;
                        insertedMoviesIds.Add(movieId);
                        foreach (var c in cast)
                        {
                            var a = new Actor();
                            a.Name = c.ToString();
                            Actor? oldActor = await _actorsRepository.FindByName(a.Name) ?? null;
                            if (oldActor != null)
                            {
                                await _service.AddExistingActorToMovie(oldActor.Id, movieId);
                                continue;
                            }
                            else 
                            { 
                                var newActor = await _actorsRepository.CreateAsync(a);
                                var actorId = newActor.Id;
                                await _service.AddExistingActorToMovie(actorId, movieId);
                            }
                        }
                    }
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
            var insertedMovies = await _service.FindAllByIds(insertedMoviesIds);
            return _mapper.Map<List<MovieDto>>(insertedMovies);
        }
    }
}
