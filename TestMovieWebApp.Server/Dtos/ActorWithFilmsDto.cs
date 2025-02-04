namespace TestMovieWebApp.Server.Dtos
{
    public class ActorWithFilmsDto
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<MovieDto> Movies { get; set; }
    }
}
