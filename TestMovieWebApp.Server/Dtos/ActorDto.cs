using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Dtos
{
    public class ActorDto
    {
        public string Name { get; set; } = string.Empty;
        public virtual Guid? MovieId { get; set; }
    }
}
