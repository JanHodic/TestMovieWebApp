using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<ActorMovie> AddExistingActorToMovie(Guid ActorId, Guid MovieId)
        {
            DbSet<ActorMovie> _dbSet = _dbEntity.ActorMovies;
            EntityEntry<ActorMovie> entityEntry = _dbSet.Add(new ActorMovie { ActorId = ActorId, MovieId = MovieId });
            try
            {
                await _dbEntity.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new Exception("new content not saved");
            }

            new Exception("new entity added");
            return entityEntry.Entity;
        }
    }
}
