using Microsoft.EntityFrameworkCore;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Data
{
    public class TestWebAppDbContext: DbContext
    {
        public TestWebAppDbContext(DbContextOptions<TestWebAppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
