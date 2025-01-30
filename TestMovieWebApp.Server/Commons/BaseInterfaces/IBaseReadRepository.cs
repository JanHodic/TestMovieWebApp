using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Commons.BaseInterfaces
{
    /// <summary>
    ///     Operations for reading records from database.
    /// </summary>
    public interface IBaseReadRepository<T>
        where T : UserDateIdentity
    {
        /// <summary>
        ///     Returns all records.
        /// </summary>
        /// <returns>Returns all records</returns>
        public Task<ICollection<T>> GetAllAsync();

        /// <summary>
        ///     Returns all records in the given interval.
        /// </summary>
        /// <param name="page">id of element where to begin.</param>
        /// <param name="pageSize">id of element where to end.</param>
        /// <returns>Returns all objects in the given interval</returns>
        public Task<ICollection<T>> GetAllAsync(int page, int pageSize);
        /// <summary>
        ///     Returns record by given id.
        /// </summary>
        /// <returns>Returns the given item</returns>
        public Task<T> GetAsync(Guid? id);
        /// <summary>
        ///     Returns record by given ids.
        /// </summary>
        /// <returns>Returns the given items</returns>
        Task<ICollection<T>> FindAllByIds(IEnumerable<Guid> ids);
    }
}
