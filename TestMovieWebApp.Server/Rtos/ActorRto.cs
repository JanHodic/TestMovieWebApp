namespace TestMovieWebApp.Server.Rtos
{
    public class ActorRto
    {
        public string Name { get; set; } = string.Empty;
        public virtual MovieRto? Movie { get; set; }
    }
}
