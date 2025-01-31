namespace TestMovieWebApp.Server.Commons.Models
{
    public class UserDateIdentity: BaseIdentity
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset LastEdited { get; set; }
        public DateTimeOffset? Deleted { get; set; }
    }
}
