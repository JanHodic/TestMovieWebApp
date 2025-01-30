namespace TestMovieWebApp.Server.Commons.Interfaces
{
    public interface IFileReader
    {
        public Task<ICollection<object>> ReadFile<MainObject, OwnedObject>();
    }
}
