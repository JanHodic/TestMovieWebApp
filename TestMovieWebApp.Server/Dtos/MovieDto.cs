using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Dtos
{
    public class MovieDto
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Guid> CastIds { get; set; } = new List<Guid>();
    }
}
