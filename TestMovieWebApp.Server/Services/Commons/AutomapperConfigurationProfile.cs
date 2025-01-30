using AutoMapper;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Services.Commons
{
    public class AutomapperConfigurationProfile: Profile
    {
        public AutomapperConfigurationProfile() 
        {
            CreateMap<MovieDto, Movie>()
                .ForMember(d => d.Actors, opt => opt.MapFrom(m => m.ActorIds));
            CreateMap<Movie, MovieDto>()
                .ForMember(d => d.ActorIds, opt => opt.MapFrom(m => m.Actors));
        }
    }
}
