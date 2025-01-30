using Microsoft.AspNetCore.Http.HttpResults;
using TestMovieWebApp.Server.Commons.Interfaces;

namespace TestMovieWebApp.Server.Presentations.Controllers
{
    public class FileController
    {
        private readonly IFileReader _service;
        public FileController(IFileReader service)
        {
            _service = service;
        }

        public async Task<ICollection<object>> ReadFile()
        {
            var contents = await _service.ReadFile<object, object>();
            return contents;
        }
    }
}
