using Microsoft.EntityFrameworkCore;
using TestMovieWebApp.Server.Commons.BaseServices;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Data.Repositories
{
    public class ActorsRepository : BaseWriteRepository<Actor, TestWebAppDbContext>, IActorsRepository
    {
        public ActorsRepository(ILogger<Actor> eventLogger, TestWebAppDbContext dbEntity) : base(eventLogger, dbEntity)
        {
        }

        public async Task<Actor> FindByName(string name)
        {
            var result = await _dbSet.Where(u => u.Name == name).ToListAsync();
            if (result == null)
            {
                Console.WriteLine("Actor does not exist");
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
