using TestMovieWebApp.Server.Commons.BaseInterfaces;
using TestMovieWebApp.Server.Commons.Interfaces;
using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Services.Commons
{
    public class FileReader<IService> : IFileReader where IService : IBaseWriteService<object, object>
    {
        private readonly IService _service;
        private readonly IConfiguration _configuration;
        public FileReader(IService service, IConfiguration configuration) 
        {
            _service = service;
            _configuration = configuration;
        }
        public async Task<ICollection<object>> ReadFile<MainObject, OwnedObject>()
        {
            var readFile = File.ReadAllText("Path");
            return await _service.CreateOrUpdateManyAsync([]);
        }
    }
}
