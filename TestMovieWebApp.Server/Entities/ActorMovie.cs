using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Entities
{
    public class ActorMovie: UserDateIdentity
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }
        public virtual Actor Actor { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
