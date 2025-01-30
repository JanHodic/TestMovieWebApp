using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Services.Modules.Actors;

namespace TestMovieWebApp.Server.Presentations.Controllers
{
    /// <summary>
    ///     Actors controller.
    /// </summary>
    [ApiController]
    [Route("actors")]
    [Produces("application/json")]
    public class ActorsControllers
    {
        private readonly IActorsService _service;
        public ActorsControllers(IActorsService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActorDto> Create(ActorDto createDto)
        {
            return await _service.CreateAsync(createDto);
        }

        [HttpGet("{id}")]
        public async Task<ActorDto> Get(Guid guid)
        {
            return await _service.GetAsync(guid);
        }

        [HttpGet]
        public async Task<ICollection<ActorDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpPut]
        public async Task<ActorDto> Update(Guid id, ActorDto dto)
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
