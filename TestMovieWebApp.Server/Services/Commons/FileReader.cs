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
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public FileReader(IMoviesRepository service, IMapper mapper, IConfiguration configuration) 
        {
            _service = service;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<ICollection<MovieDto>> ReadFile()
        {
            var movies = new List<Movie>();
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
                        foreach(var c in cast)
                        {
                            var a = new Actor();
                            a.Name = c.ToString();
                            m.Cast.Add(a);
                        }
                        movies.Add(m);
                    }
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            var insertedMoviesIds = await _service.CreateOrUpdateManyAsync(movies);
            
            var insertedMovies = await _service.FindAllByIds(insertedMoviesIds);
            return _mapper.Map<List<MovieDto>>(insertedMovies);
        }
    }
}
