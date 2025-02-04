using Microsoft.EntityFrameworkCore;
using TestMovieWebApp.Server.Commons.BaseServices;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Data.Repositories
{
    public class MoviesRepository : BaseWriteRepository<Movie, TestWebAppDbContext>, IMoviesRepository
    {
        public MoviesRepository(ILogger<Movie> eventLogger, TestWebAppDbContext dbEntity) : base(eventLogger, dbEntity)
        {
        }

        public async Task<Movie> FindByTitle(string title)
        {
            var result = await _dbSet.Where(u => u.Title == title).ToListAsync();
            if (result == null)
            {
                Console.WriteLine("User does not exist");
                return null;
            }

            else
            {
                var r = result.FirstOrDefault();
                if (r is null)
                {
                    Console.WriteLine("User does not exist");
                    return null;
                }
                else
                {
                    return r;
                }
            }
        }
    }
}
