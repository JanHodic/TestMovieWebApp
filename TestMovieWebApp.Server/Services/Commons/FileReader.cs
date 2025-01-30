using TestMovieWebApp.Server.Commons.BaseInterfaces;
using TestMovieWebApp.Server.Commons.BaseServices;
using TestMovieWebApp.Server.Commons.Interfaces;
using TestMovieWebApp.Server.Commons.Models;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Entities;
using TestMovieWebApp.Server.Services.Modules.Actors;

namespace TestMovieWebApp.Server.Services.Commons
{
    public class FileReader: IFileReader
    {
        private readonly IActorsService _service;
        private readonly IConfiguration _configuration;
        public FileReader(IActorsService service, IConfiguration configuration) 
        {
            _service = service;
            _configuration = configuration;
        }
        public async Task<ICollection<ActorDto>> ReadFile()
        {
            var path = _configuration.GetSection("Path").Value ?? "";
            var readFile = File.ReadAllText(path);
            return await _service.CreateOrUpdateManyAsync(new List<ActorDto>());
        }
    }
}
