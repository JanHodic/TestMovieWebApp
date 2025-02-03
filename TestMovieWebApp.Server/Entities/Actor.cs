using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Entities
{
    public class Actor: UserDateIdentity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Movie>? Movies { get; set; } = new List<Movie>();
    }
}
