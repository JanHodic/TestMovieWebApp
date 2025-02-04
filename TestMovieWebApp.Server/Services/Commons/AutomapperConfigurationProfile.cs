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
            //CreateMap<List<MovieDto>, List<Movie>>();
            //.ForMember(d => d.Cast, opt => opt.Ignore());
            CreateMap<Movie, MovieDto>();
            //CreateMap<List<Movie>, List<MovieDto>>();
            //.ForMember(m => m.CastIds, opt => opt.ConvertUsing<ToIdsConverter, List<Actor>>());
            CreateMap<ActorDto, Actor>()
                .ForMember(d => d.Movies, opt => opt.Ignore());
            CreateMap<Actor, ActorDto>()
                .ForMember(d => d.MovieIds, opt => opt.Ignore());
            CreateMap<Movie, ActorWithFilmsDto>();
            //CreateMap<List<Actor>, List<ActorDto>>();
            //CreateMap<List<ActorDto>, List<Actor>>();
        }
        
        private class ToIdsConverter : IValueConverter<List<Actor>, List<Guid>>
        {
            public List<Guid> Convert(List<Actor> sourceMember, ResolutionContext context) =>
                sourceMember.Select(p => p.Id).ToList();
        }
    }
}
