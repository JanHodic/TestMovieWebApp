using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Rtos
{
    public class MovieRto
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<MovieRto> Cast { get; set; } = new List<MovieRto>();
    }
}
