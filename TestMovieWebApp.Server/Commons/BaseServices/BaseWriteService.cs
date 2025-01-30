using AutoMapper;
using TestMovieWebApp.Server.Commons.BaseInterfaces;
using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Commons.BaseServices
{

    public class BaseWriteService<Repository, T, Dto, DtoCreate> : BaseReadService<Repository, T, Dto>, IBaseReadService<Dto>, IBaseWriteService<Dto, DtoCreate>
        where T : UserDateIdentity
        where Dto : class
        where DtoCreate : class
        where Repository : IBaseReadRepository<T>, IBaseWriteRepository<T>
    {
        public BaseWriteService(ILogger<T> eventLogger, Repository repository, IMapper mapper) : base(eventLogger, repository, mapper)
        {
        }

        public virtual async Task<Dto> CreateAsync(DtoCreate item)
        {
            var entity = _mapper.Map<T>(item);
            var saved = await _repository.CreateAsync(entity);
            return _mapper.Map<Dto>(saved);
        }

        public async Task<ICollection<Dto>> CreateOrUpdateManyAsync(ICollection<Dto> items)
        {
            var entities = _mapper.Map<ICollection<T>>(items);
            var saved = await _repository.CreateOrUpdateManyAsync(entities);
            return _mapper.Map<ICollection<Dto>>(saved);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<Dto> UpdateAsync(Guid id, Dto item)
        {
            var entity = _mapper.Map<T>(item);
            var saved = await _repository.UpdateAsync(id, entity);
            return _mapper.Map<Dto>(saved);
        }
    }
}
