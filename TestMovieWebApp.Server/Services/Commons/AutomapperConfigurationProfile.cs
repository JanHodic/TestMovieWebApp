using AutoMapper;
using TestMovieWebApp.Server.Dtos;
using TestMovieWebApp.Server.Entities;

namespace TestMovieWebApp.Server.Services.Commons
{
    public class AutomapperConfigurationProfile: Profile
    {
        public AutomapperConfigurationProfile() 
        {
            CreateMap<MovieDto, Movie>();
                //.ForMember(d => d.Cast, opt => opt.Ignore());
            CreateMap<Movie, MovieDto>();
                //.ForMember(m => m.CastIds, opt => opt.ConvertUsing<ToIdsConverter, List<Actor>>());
            CreateMap<ActorDto, Actor>()
                .ForMember(d => d.Movie, opt => opt.Ignore());
            CreateMap<Actor, ActorDto>()
                .ForMember(d => d.MovieId, opt => opt.Ignore());
        }
        
        private class ToIdsConverter : IValueConverter<List<Actor>, List<Guid>>
        {
            public List<Guid> Convert(List<Actor> sourceMember, ResolutionContext context) =>
                sourceMember.Select(p => p.Id).ToList();
        }
    }
}
