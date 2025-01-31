using TestMovieWebApp.Server.Commons.Models;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Commons.Interfaces
{
    public interface IFileReader
    {
        public Task<ICollection<MovieDto>> ReadFile();
    }
}
