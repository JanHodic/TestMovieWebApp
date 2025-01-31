using AutoMapper;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Entities;
using TestMovieWebApp.Server.Rtos;

namespace TestMovieWebApp.Server.Services.Commons
{
    public class AutomapperConfigurationProfile: Profile
    {
        public AutomapperConfigurationProfile() 
        {
            CreateMap<MovieDto, Movie>()
                .ForMember(d => d.Cast, opt => opt.MapFrom(m => m.CastIds));
            CreateMap<Movie, MovieDto>()
                .ForMember(d => d.CastIds, opt => opt.MapFrom(m => m.Cast));
            CreateMap<ActorDto, Actor>()
                .ForMember(d => d.Movie, opt => opt.MapFrom(m => m.MovieId));
            CreateMap<Actor, ActorDto>()
                .ForMember(d => d.MovieId, opt => opt.MapFrom(m => m.Movie));
        }
    }
}
