using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actor>()
                .HasMany<Movie>(s => s.Movies)
                .WithMany(c => c.Cast)
                .UsingEntity("ActorMovie",
                l => l.HasOne(typeof(Movie)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(Movie.Id)),
                r => r.HasOne(typeof(Actor)).WithMany().HasForeignKey("ActorId").HasPrincipalKey(nameof(Actor.Id)),
                j => j.HasKey("MovieId", "ActorId"));

            IEnumerable<IMutableForeignKey> cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(type => type.GetForeignKeys())
                .Where(foreignKey => !foreignKey.IsOwnership && foreignKey.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var foreignKey in cascadeFKs)
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
