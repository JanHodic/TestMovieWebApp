using TestMovieWebApp.Server.Commons.Models;

namespace TestMovieWebApp.Server.Entities
{
    public class Actor: BaseIdentity
    {
        public string Name { get; set; } = string.Empty;
        public virtual Guid? MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
