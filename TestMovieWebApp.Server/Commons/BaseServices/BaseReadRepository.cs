using Microsoft.EntityFrameworkCore;
using TestMovieWebApp.Server.Commons.BaseInterfaces;
using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Commons.BaseServices
{
    public class BaseReadRepository<T, TDbContext> : IBaseReadRepository<T>
        where T : UserDateIdentity
        where TDbContext : DbContext
    {
        protected ILogger<T> _eventLogger;
        protected readonly TDbContext _dbEntity;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        ///     Reading features for database.
        /// </summary>
        /// <param name="eventLogger">Event logger variable.</param>
        /// <param name="dbEntity">Database entity.</param>
        public BaseReadRepository(ILogger<T> eventLogger, TDbContext dbEntity)
        {
            _dbEntity = dbEntity;
            _dbSet = dbEntity.Set<T>();
            _eventLogger = eventLogger;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync<T>();
        }

        public virtual async Task<ICollection<T>> GetAllAsync(int page, int pageSize)
        {
            return await _dbSet
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public virtual async Task<T> GetAsync(Guid? id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result == null) throw new Exception("Not found");
            else return result;
        }

        public virtual async Task<ICollection<T>> FindAllByIds(IEnumerable<Guid> ids)
        {
            return await _dbSet.Where(p => ids.Contains(p.Id)).ToListAsync();
        }
    }
}
