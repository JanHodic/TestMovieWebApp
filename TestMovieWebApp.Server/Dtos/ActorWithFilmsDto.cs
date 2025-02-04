using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Dtos
{
    public class ActorWithFilmsDto
    {
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
