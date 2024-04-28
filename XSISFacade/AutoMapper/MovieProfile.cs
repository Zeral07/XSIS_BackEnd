using AutoMapper;
using XSISDataAccess.Models;
using XSISDataAccess.ViewModel;

namespace XSISFacade.AutoMapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
        }
    }
}
