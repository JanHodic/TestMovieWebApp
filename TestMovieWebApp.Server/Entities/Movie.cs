using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Entities
{
    public class Movie: UserDateIdentity
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Actor> Cast {  get; set; } = new List<Actor>(); 
    }
}
