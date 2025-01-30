using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Services.Modules.Movies;

namespace TestMovieWebApp.Server.Presentations.Controllers
{
    /// <summary>
    ///     Movies controller.
    /// </summary>
    [ApiController]
    [Route("movies")]
    [Produces("application/json")]
    public class MoviesController
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<MovieDto> Create(MovieDto createDesignDto)
        {
            return await _service.CreateAsync(createDesignDto);
        }

        [HttpGet("{id}")]
        public async Task<MovieDto> Get(Guid guid)
        {
            return await _service.GetAsync(guid);
        }

        [HttpGet]
        public async Task<ICollection<MovieDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpPut]
        public async Task<MovieDto> Update(Guid id, MovieDto dto)
        {
            return await _service.UpdateAsync(id, dto);
        }

        [HttpDelete]
        public async Task<bool> Delete(Guid id)
        {
            return await _service.DeleteAsync(id);
        }
    }
}
