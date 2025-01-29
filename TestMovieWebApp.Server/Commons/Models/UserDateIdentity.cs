namespace TestMovieWebApp.Server.Commons.Models
{
    public class UserDateIdentity: BaseIdentity
    {
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTimeOffset LastEdited { get; set; }
        public string LastEditedBy { get; set; } = string.Empty;
        public DateTimeOffset? Deleted { get; set; }
        public string? DeletedBy { get; set; }
    }
}
