using AutoMapper;
using XSISDataAccess.Models;
using XSISDataAccess.ViewModel;

namespace XSISFacade.AutoMapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Created_At, act => act.MapFrom(src => DateTime.SpecifyKind(src.Created_At, DateTimeKind.Utc)))
                .ForMember(dest => dest.Updated_At, act => act.MapFrom(src => DateTime.SpecifyKind(src.Updated_At ?? DateTime.Now, DateTimeKind.Utc)));
            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Created_At, act => act.MapFrom(src => DateTime.SpecifyKind(src.Created_At, DateTimeKind.Utc)))
                .ForMember(dest => dest.Updated_At, act => act.MapFrom(src => DateTime.SpecifyKind(src.Updated_At ?? DateTime.Now, DateTimeKind.Utc)));
        }
    }
}
