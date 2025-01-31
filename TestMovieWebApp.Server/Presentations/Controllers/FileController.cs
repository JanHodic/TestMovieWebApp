using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestMovieWebApp.Server.Commons.Interfaces;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Presentations.Controllers
{
    /// <summary>
    ///     Files controller.
    /// </summary>
    [ApiController]
    [Route("files")]
    [Produces("application/json")]
    public class FileController
    {
        private readonly IFileReader _service;
        public FileController(IFileReader service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ICollection<MovieDto>> ReadFile()
        {
            var contents = await _service.ReadFile();
            return contents;
        }
    }
}
