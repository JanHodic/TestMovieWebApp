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
                .ForMember(d => d.Actors, opt => opt.MapFrom(m => m.ActorIds));
            CreateMap<Movie, MovieDto>()
                .ForMember(d => d.ActorIds, opt => opt.MapFrom(m => m.Actors));
            CreateMap<ActorDto, Actor>()
                .ForMember(d => d.Movie, opt => opt.MapFrom(m => m.MovieId));
            CreateMap<Actor, ActorDto>()
                .ForMember(d => d.MovieId, opt => opt.MapFrom(m => m.Movie));
            CreateMap<ActorRto, Actor>()
                .ForMember(d => d.Movie, opt => opt.MapFrom(m => m.Movie));
            CreateMap<MovieRto, Movie>()
                .ForMember(d => d.Actors, opt => opt.MapFrom(m => m.Actors));
        }
    }
}
