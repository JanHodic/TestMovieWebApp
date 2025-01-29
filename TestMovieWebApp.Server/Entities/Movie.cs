using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Entities
{
    public class Movie: BaseIdentity
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Actor> Actors {  get; set; } = new List<Actor>(); 
    }
}
